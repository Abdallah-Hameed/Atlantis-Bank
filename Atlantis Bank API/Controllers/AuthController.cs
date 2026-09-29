using Atlantis_Bank_API.DTOs.Auth;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Atlantis_Bank_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private const string AuthFailureMessage =
            "Invalid credentials. If this continues, please wait before trying again.";

        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        private IActionResult AuthFail()
            => Unauthorized(new { message = AuthFailureMessage });

        [EnableRateLimiting("AuthLimiter")]
        [HttpPost("login")]
        public IActionResult Login([FromBody] clsLoginDto request)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            clsUser user = clsUser.FindByUserName(request.UserName);

            if (user == null)
            {
                _logger.LogWarning(
                    "Login failed (user not found). UserName={UserName}, IP={IP}",
                    request.UserName,
                    ip);

                return AuthFail();
            }

            if (!user.Active)
            {
                _logger.LogWarning(
                    "Login failed (inactive account). UserID={UserID}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip);

                return AuthFail();
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isValidPassword)
            {
                _logger.LogWarning(
                    "Login failed (bad password). UserID={UserID}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip);

                return AuthFail();
            }

            var accessToken = GenerateAccessToken(user);

            var refreshToken = GenerateRefreshToken();

            string refreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);
            DateTime expiresAt = DateTime.UtcNow.AddDays(7);

            user.SaveRefreshToken(refreshTokenHash, expiresAt);

            _logger.LogInformation(
                "Login succeeded. UserID={UserID}, UserName={UserName}, IP={IP}",
                user.UserID,
                user.UserName,
                ip);

            return Ok(new clsTokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [EnableRateLimiting("AuthLimiter")]
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] clsRefreshDto request)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            clsUser user = clsUser.FindByUserName(request.UserName);

            if (user == null)
            {
                _logger.LogWarning(
                    "Refresh failed (user not found). UserName={UserName}, IP={IP}",
                    request.UserName,
                    ip);

                return AuthFail();
            }

            if (user.RefreshTokenRevokedAt != null)
            {
                _logger.LogWarning(
                    "Refresh failed (revoked). UserID={UserID}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip);

                return AuthFail();
            }

            if (user.RefreshTokenExpiresAt == null || user.RefreshTokenExpiresAt <= DateTime.UtcNow)
            {
                _logger.LogWarning(
                    "Refresh failed (expired). UserID={UserID}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip);

                return AuthFail();
            }

            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, user.RefreshTokenHash);
            if (!refreshValid)
            {
                _logger.LogWarning(
                    "Refresh failed (invalid token). UserID={UserID}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip);

                return AuthFail();
            }

            var newAccessToken = GenerateAccessToken(user);

            var newRefreshToken = GenerateRefreshToken();
            string newRefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(newRefreshToken);
            DateTime newExpiresAt = DateTime.UtcNow.AddDays(7);

            user.SaveRefreshToken(newRefreshTokenHash, newExpiresAt);

            _logger.LogInformation(
                "Refresh succeeded. UserID={UserID}, UserName={UserName}, IP={IP}",
                user.UserID,
                user.UserName,
                ip);

            return Ok(new clsTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] clsLogoutDto request)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            clsUser user = clsUser.FindByUserName(request.UserName);

            if (user == null)
            {
                _logger.LogWarning(
                    "Logout attempted (user not found). UserName={UserName}, IP={IP}",
                    request.UserName,
                    ip);

                return Ok(new { message = "Logged out successfully" });
            }

            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, user.RefreshTokenHash);
            if (!refreshValid)
            {
                _logger.LogWarning(
                    "Logout failed (invalid refresh token). UserID={UserID}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip);

                return Ok(new { message = "Logged out successfully" });
            }

            user.RevokeRefreshToken();

            _logger.LogInformation(
                "Logout succeeded. UserID={UserID}, UserName={UserName}, IP={IP}",
                user.UserID,
                user.UserName,
                ip);

            return Ok(new { message = "Logged out successfully" });
        }

        private string GenerateAccessToken(clsUser user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.Role.RoleDescription),
        new Claim("RoleID", user.Role.RoleID.ToString())
    };

            List<string> rolePermissions = user.Role.GetPermissions();

            foreach (string permission in rolePermissions)
            {
                claims.Add(new Claim("Permission", permission));
            }

            if (user.EmployeeInfo != null && user.EmployeeInfo.PositionInfo != null)
            {
                HashSet<string> positionPermissions = clsAuthorization.GetPositionPermissions(
                    user.EmployeeInfo.PositionInfo.PositionID);

                foreach (string permission in positionPermissions)
                {
                    claims.Add(new Claim("PositionPermission", permission));
                }
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
using Atlantis_Bank_API.DTOs.Auth;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] clsLoginDto request)
        {

            clsUser user = clsUser.FindByUserName(request.UserName);

            if (user == null)
                return Unauthorized("Invalid credentials");


            if (!user.Active)
                return Unauthorized("User account is inactive");

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isValidPassword)
                return Unauthorized("Invalid credentials");


            var accessToken = GenerateAccessToken(user);


            var refreshToken = GenerateRefreshToken();

            string refreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);
            DateTime expiresAt = DateTime.UtcNow.AddDays(7);

            user.SaveRefreshToken(refreshTokenHash, expiresAt);

            return Ok(new clsTokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }


        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] clsRefreshDto request)
        {

            clsUser user = clsUser.FindByUserName(request.UserName);

            if (user == null)
                return Unauthorized("Invalid refresh request");


            if (user.RefreshTokenRevokedAt != null)
                return Unauthorized("Refresh token is revoked");


            if (user.RefreshTokenExpiresAt == null || user.RefreshTokenExpiresAt <= DateTime.UtcNow)
                return Unauthorized("Refresh token expired");


            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, user.RefreshTokenHash);
            if (!refreshValid)
                return Unauthorized("Invalid refresh token");

            var newAccessToken = GenerateAccessToken(user);


            var newRefreshToken = GenerateRefreshToken();
            string newRefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(newRefreshToken);
            DateTime newExpiresAt = DateTime.UtcNow.AddDays(7);


            user.SaveRefreshToken(newRefreshTokenHash, newExpiresAt);

            return Ok(new clsTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }


        [HttpPost("logout")]
        public IActionResult Logout([FromBody] clsLogoutDto request)
        {
            clsUser user = clsUser.FindByUserName(request.UserName);

            if (user == null)
                return Ok();

            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, user.RefreshTokenHash);
            if (!refreshValid)
                return Ok();

            user.RevokeRefreshToken();

            return Ok("Logged out successfully");
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

            if (user.EmployeeInfo != null)
            {
                claims.Add(new Claim("EmployeeID", user.EmployeeInfo.EmployeeID.ToString()));
            }

            // Role Permissions
            List<string> rolePermissions = user.Role.GetPermissions();
            foreach (string permission in rolePermissions)
            {
                claims.Add(new Claim("Permission", permission));
            }

            // Position Permissions
            if (user.EmployeeInfo != null && user.EmployeeInfo.PositionInfo != null)
            {
                claims.Add(new Claim("PositionID", user.EmployeeInfo.PositionInfo.PositionID.ToString()));

                HashSet<string> positionPermissions = clsAuthorization.GetPositionPermissions(
                    user.EmployeeInfo.PositionInfo.PositionID);

                foreach (string permission in positionPermissions)
                {
                    claims.Add(new Claim("PositionPermission", permission));
                }
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_FOR_ATLANTIS_BANK_123456"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AtlantisBankApi",
                audience: "AtlantisBankClients",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
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
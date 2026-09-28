using Atlantis_Bank_API.DTOs.Auth;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Atlantis_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login(clsLoginDto dto)
        {
            clsUser user = clsUser.FindByUserName(dto.UserName);

            if (user == null)
                return Unauthorized("Invalid credentials");

            if (!user.Active)
                return Unauthorized("User account is inactive");

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!isValidPassword)
                return Unauthorized("Invalid credentials");

            return Ok();
        }
    }
}
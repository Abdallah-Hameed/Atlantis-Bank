using Atlantis_Bank_API.Authorization;
using Atlantis_Bank_API.DTOs.User;
using Atlantis_Bank_API.Mappers;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Atlantis_Bank_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize(Policy = "User_View")]
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsUserListDto>>> GetAllUsers()
        {
            DataTable dt = await clsUser.GetAllUsers();

            IEnumerable<clsUserListDto> users = clsUserMapper.Map(dt);

            return Ok(users);
        }

        [Authorize(Policy = "User_View")]
        [HttpGet("{id}")]
        public ActionResult<clsUserDto> GetUserById(int id)
        {
            clsUser user = clsUser.Find(id);

            if (user == null)
                return NotFound("User is not found");

            clsUserDto dto = clsUserMapper.Map(user);

            return Ok(dto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser(
            clsAddUserDto dto,
            [FromServices] IAuthorizationService authService)
        {
            var resource = new clsUserAddResource { NewRoleId = dto.RoleID };

            var authResult = await authService.AuthorizeAsync(User, resource, "User_AddPolicy");

            if (!authResult.Succeeded)
                return StatusCode(403, "You cannot create a user with a role equal to or higher than yours.");

            clsUser user = new clsUser();

            clsUserMapper.MapToUser(dto, user);

            enOperationResult result = user.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to add users.");

            if (result == enOperationResult.UsernameExists)
                return Conflict("Username already exists");

            if (result == enOperationResult.RoleNotFound)
                return NotFound("Role is not found");

            if (result == enOperationResult.EmployeeNotFound)
                return NotFound("Employee is not found");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok(user.UserID);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(
            int id,
            clsUpdateUserDto dto,
            [FromServices] IAuthorizationService authService)
        {
            clsUser user = clsUser.Find(id);

            if (user == null)
                return NotFound("User is not found");

            var resource = new clsUserUpdateResource
            {
                TargetUserId = id,
                TargetCurrentRoleId = user.Role.RoleID,
                NewRoleId = dto.RoleID
            };

            var authResult = await authService.AuthorizeAsync(User, resource, "User_EditOrSelf");

            if (!authResult.Succeeded)
                return StatusCode(403, "You do not have permission to edit this user or assign this role.");

            clsUserMapper.MapToUser(dto, user);

            enOperationResult result = user.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to edit users.");

            if (result == enOperationResult.RoleNotFound)
                return NotFound("Role is not found");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok();
        }

        [Authorize(Policy = "User_Delete")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            enOperationResult result = clsUser.Delete(id);

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to delete users.");

            if (result == enOperationResult.NotFound)
                return NotFound("User is not found");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return NoContent();
        }

        [Authorize(Policy = "User_ChangePassword")]
        [HttpPut("{id}/ChangePassword")]
        public IActionResult ChangePassword(int id, clsChangePasswordDto dto)
        {
            clsUser user = clsUser.Find(id);

            if (user == null)
                return NotFound("User is not found");

            enOperationResult result = user.ChangePassword(dto.OldPassword, dto.NewPassword);

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to change this password.");

            if (result == enOperationResult.InvalidPassword)
                return BadRequest("Old password is incorrect.");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok();
        }
    }
}
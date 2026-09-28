using Atlantis_Bank_API.DTOs.User;
using Atlantis_Bank_API.Mappers;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Atlantis_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsUserListDto>>> GetAllUsers()
        {
            DataTable dt = await clsUser.GetAllUsers();

            IEnumerable<clsUserListDto> users = clsUserMapper.Map(dt);

            return Ok(users);
        }


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
        public IActionResult AddUser(clsAddUserDto dto)
        {
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
        public IActionResult UpdateUser(int id, clsUpdateUserDto dto)
        {
            clsUser user = clsUser.Find(id);

            if (user == null)
                return NotFound("User is not found");

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

        [HttpPut("{id}/ChangePassword")]
        public IActionResult ChangePassword(int id, clsChangePasswordDto dto)
        {
            clsUser user = clsUser.Find(id);

            if (user == null)
                return NotFound("User is not found");

            enOperationResult result = user.ChangePassword(dto.Password);

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to change this password.");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok();
        }
    }
}
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
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

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
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            var resource = new clsUserAddResource { NewRoleId = dto.RoleID };

            var authResult = await authService.AuthorizeAsync(User, resource, "User_AddPolicy");

            if (!authResult.Succeeded)
            {
                _logger.LogWarning(
                    "AddUser blocked (role escalation attempt). Actor={ActorId}/{ActorName}, AttemptedRoleID={RoleID}, IP={IP}",
                    actorId, actorName, dto.RoleID, ip);

                return StatusCode(403, "You cannot create a user with a role equal to or higher than yours.");
            }

            clsUser user = new clsUser();

            clsUserMapper.MapToUser(dto, user);

            enOperationResult result = user.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "AddUser failed (no permission). Actor={ActorId}/{ActorName}, NewUserName={NewUserName}, IP={IP}",
                    actorId, actorName, dto.UserName, ip);

                return StatusCode(403, "You do not have permission to add users.");
            }

            if (result == enOperationResult.UsernameExists)
                return Conflict("Username already exists");

            if (result == enOperationResult.RoleNotFound)
                return NotFound("Role is not found");

            if (result == enOperationResult.EmployeeNotFound)
                return NotFound("Employee is not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "AddUser failed (unexpected error). Actor={ActorId}/{ActorName}, NewUserName={NewUserName}, IP={IP}",
                    actorId, actorName, dto.UserName, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "AddUser succeeded. Actor={ActorId}/{ActorName}, NewUserID={NewUserID}, NewUserName={NewUserName}, RoleID={RoleID}, IP={IP}",
                actorId, actorName, user.UserID, user.UserName, dto.RoleID, ip);

            return Ok(user.UserID);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(
            int id,
            clsUpdateUserDto dto,
            [FromServices] IAuthorizationService authService)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

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
            {
                _logger.LogWarning(
                    "UpdateUser blocked. Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, TargetRole={TargetRole}, NewRole={NewRole}, IP={IP}",
                    actorId, actorName, id, user.Role.RoleID, dto.RoleID, ip);

                return StatusCode(403, "You do not have permission to edit this user or assign this role.");
            }

            clsUserMapper.MapToUser(dto, user);

            enOperationResult result = user.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "UpdateUser failed (no permission). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to edit users.");
            }

            if (result == enOperationResult.RoleNotFound)
                return NotFound("Role is not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "UpdateUser failed (unexpected error). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "UpdateUser succeeded. Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, NewRoleID={NewRoleID}, IP={IP}",
                actorId, actorName, id, dto.RoleID, ip);

            return Ok();
        }

        [Authorize(Policy = "User_Delete")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            enOperationResult result = clsUser.Delete(id);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "DeleteUser failed (no permission). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to delete users.");
            }

            if (result == enOperationResult.NotFound)
                return NotFound("User is not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "DeleteUser failed (unexpected error). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogWarning(
                "DeleteUser succeeded (sensitive operation). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                actorId, actorName, id, ip);

            return NoContent();
        }

        [Authorize(Policy = "User_ChangePassword")]
        [HttpPut("{id}/ChangePassword")]
        public IActionResult ChangePassword(int id, clsChangePasswordDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsUser user = clsUser.Find(id);

            if (user == null)
                return NotFound("User is not found");

            bool isSelf = (actorId == id.ToString());

            enOperationResult result = user.ChangePassword(dto.OldPassword, dto.NewPassword);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "ChangePassword blocked (no permission). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to change this password.");
            }

            if (result == enOperationResult.InvalidPassword)
            {
                _logger.LogWarning(
                    "ChangePassword failed (wrong old password). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest("Old password is incorrect.");
            }

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "ChangePassword failed (unexpected error). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            if (isSelf)
            {
                _logger.LogInformation(
                    "ChangePassword succeeded (self). Actor={ActorId}/{ActorName}, IP={IP}",
                    actorId, actorName, ip);
            }
            else
            {
                _logger.LogWarning(
                    "ChangePassword succeeded (admin reset). Actor={ActorId}/{ActorName}, TargetUserID={TargetUserID}, IP={IP}",
                    actorId, actorName, id, ip);
            }

            return Ok();
        }
    }
}
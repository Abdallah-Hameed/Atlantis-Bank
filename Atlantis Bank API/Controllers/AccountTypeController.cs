using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly ILogger<AccountTypeController> _logger;

        public AccountTypeController(ILogger<AccountTypeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Account_View")]
        [HttpGet("{id}")]
        public ActionResult<clsAccountTypeDTO> GetAccountTypeByID(int id)
        {
            clsAccountType accountType = clsAccountType.Find(id);

            if (accountType == null)
                return NotFound();

            clsAccountTypeDTO dto = clsAccountTypeMapper.ToDTO(accountType);

            return Ok(dto);
        }

        [Authorize(Policy = "Account_Edit")]
        [HttpPut("{id}")]
        public IActionResult UpdateAccountType(int id, clsAccountTypeDTO dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsAccountType accountType = clsAccountType.Find(id);

            if (accountType == null)
                return NotFound();

            accountType.AccountTypeDescription = dto.AccountTypeDescription;

            if (!accountType.Save())
            {
                _logger.LogError(
                    "UpdateAccountType failed (unexpected error). Actor={ActorId}/{ActorName}, TargetAccountTypeID={TargetAccountTypeID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            _logger.LogInformation(
                "UpdateAccountType succeeded. Actor={ActorId}/{ActorName}, TargetAccountTypeID={TargetAccountTypeID}, IP={IP}",
                actorId, actorName, id, ip);

            return Ok();
        }

        [Authorize(Policy = "Account_View")]
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsAccountTypeDTO>>> GetAllAccountTypes()
        {
            DataTable dt = await clsAccountType.GetAllAccountTypes();

            IEnumerable<clsAccountTypeDTO> accountTypes = clsAccountTypeMapper.ToDTOList(dt);

            return Ok(accountTypes);
        }
    }
}
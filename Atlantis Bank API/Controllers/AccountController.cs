using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Atlantis_Bank_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Account_View")]
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsListAccountDto>>> GetAllAccounts()
        {
            DataTable dt = await clsAccount.GetAllAccountsAsync();

            IEnumerable<clsListAccountDto> accounts = clsAccountMapper.ToDTOList(dt);

            return Ok(accounts);
        }

        [Authorize(Policy = "Account_View")]
        [HttpGet("{id}")]
        public ActionResult<clsAccountDto> GetAccountById(int id)
        {
            clsAccount account = clsAccount.Find(id);

            if (account == null)
                return NotFound();

            clsAccountDto dto = clsAccountMapper.ToDTO(account);

            return Ok(dto);
        }

        [Authorize(Policy = "Account_Add")]
        [HttpPost("Add")]
        public IActionResult AddAccount(clsAddAccountDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsAccount account = new clsAccount();

            clsAccountMapper.MapToAccount(dto, account);

            enOperationResult result = account.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "AddAccount failed (no permission). Actor={ActorId}/{ActorName}, PersonID={PersonID}, IP={IP}",
                    actorId, actorName, dto.PersonID, ip);

                return StatusCode(403, "You do not have permission to add accounts.");
            }

            if (result == enOperationResult.PersonNotFound)
            {
                _logger.LogWarning(
                    "AddAccount failed (person not found). Actor={ActorId}/{ActorName}, PersonID={PersonID}, IP={IP}",
                    actorId, actorName, dto.PersonID, ip);

                return NotFound("Person not found.");
            }

            if (result == enOperationResult.AccountTypeAlreadyExists)
            {
                _logger.LogWarning(
                    "AddAccount failed (account type exists). Actor={ActorId}/{ActorName}, PersonID={PersonID}, AccountTypeID={AccountTypeID}, IP={IP}",
                    actorId, actorName, dto.PersonID, dto.AccountTypeID, ip);

                return Conflict("Person already has an account of this type.");
            }

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "AddAccount failed (unexpected error). Actor={ActorId}/{ActorName}, PersonID={PersonID}, IP={IP}",
                    actorId, actorName, dto.PersonID, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "AddAccount succeeded. Actor={ActorId}/{ActorName}, NewAccountID={AccountID}, PersonID={PersonID}, AccountTypeID={AccountTypeID}, IP={IP}",
                actorId, actorName, account.AccountID, dto.PersonID, dto.AccountTypeID, ip);

            return Ok(account.AccountID);
        }

        [Authorize(Policy = "Account_Edit")]
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, clsUpdateAccountDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsAccount account = clsAccount.Find(id);

            if (account == null)
                return NotFound();

            clsAccountMapper.MapToAccount(dto, account);

            enOperationResult result = account.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "UpdateAccount failed (no permission). Actor={ActorId}/{ActorName}, TargetAccountID={TargetAccountID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to edit accounts.");
            }

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "UpdateAccount failed (unexpected error). Actor={ActorId}/{ActorName}, TargetAccountID={TargetAccountID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "UpdateAccount succeeded. Actor={ActorId}/{ActorName}, TargetAccountID={TargetAccountID}, IP={IP}",
                actorId, actorName, id, ip);

            return Ok();
        }

        [Authorize(Policy = "Account_Delete")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            enOperationResult result = clsAccount.Delete(id);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "DeleteAccount failed (no permission). Actor={ActorId}/{ActorName}, TargetAccountID={TargetAccountID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to delete accounts.");
            }

            if (result == enOperationResult.NotFound)
                return NotFound();

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "DeleteAccount failed (unexpected error). Actor={ActorId}/{ActorName}, TargetAccountID={TargetAccountID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogWarning(
                "DeleteAccount succeeded (sensitive operation). Actor={ActorId}/{ActorName}, TargetAccountID={TargetAccountID}, IP={IP}",
                actorId, actorName, id, ip);

            return NoContent();
        }

        [Authorize(Policy = "Account_View")]
        [HttpGet("{id}/Balance")]
        public async Task<ActionResult<decimal>> GetBalance(int id)
        {
            decimal? balance = await clsAccount.GetBalanceAsync(id);

            if (balance == null)
                return NotFound();

            return Ok(balance);
        }
    }
}
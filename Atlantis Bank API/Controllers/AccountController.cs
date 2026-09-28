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
            clsAccount account = new clsAccount();

            clsAccountMapper.MapToAccount(dto, account);

            enOperationResult result = account.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to add accounts.");

            if (result == enOperationResult.PersonNotFound)
                return NotFound("Person not found.");

            if (result == enOperationResult.AccountTypeAlreadyExists)
                return Conflict("Person already has an account of this type.");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok(account.AccountID);
        }

        [Authorize(Policy = "Account_Edit")]
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, clsUpdateAccountDto dto)
        {
            clsAccount account = clsAccount.Find(id);

            if (account == null)
                return NotFound();

            clsAccountMapper.MapToAccount(dto, account);

            enOperationResult result = account.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to edit accounts.");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok();
        }

        [Authorize(Policy = "Account_Delete")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            enOperationResult result = clsAccount.Delete(id);

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to delete accounts.");

            if (result == enOperationResult.NotFound)
                return NotFound();

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

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
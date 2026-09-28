using Atlantis_Bank_API.DTOs.Transaction;
using Atlantis_Bank_API.Mappers;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Atlantis_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(clsDepositDto dto)
        {
            enOperationResult result =
                await clsTransaction.DepositAsync(
                    dto.AccountID,
                    dto.Amount,
                    dto.EmployeeID);

            if (result == enOperationResult.NoPermission)
                return BadRequest("You do not have permission to deposit.");

            if (result == enOperationResult.AccountNotFound)
                return BadRequest("Account not found.");

            if (result == enOperationResult.InvalidOperation)
                return BadRequest("Invalid deposit operation.");

            if (result == enOperationResult.InActiveAccount)
                return BadRequest("The account is inactive.");

            if (result == enOperationResult.Failed)
                return BadRequest("The deposit operation failed.");

            return Ok(result);
        }

        [HttpPost("Withdrawal")]
        public async Task<IActionResult> Withdrawal(clsWithdrawalDto dto)
        {
            enOperationResult result =
                await clsTransaction.WithdrawalAsync(
                    dto.AccountID,
                    dto.Amount,
                    dto.EmployeeID);

            if (result == enOperationResult.NoPermission)
                return BadRequest("You do not have permission to withdraw.");

            if (result == enOperationResult.AccountNotFound)
                return BadRequest("Account not found.");

            if (result == enOperationResult.InvalidOperation)
                return BadRequest(
                    "Invalid withdrawal operation. " +
                    "The amount must be greater than zero and cannot exceed the account balance.");

            if (result == enOperationResult.InActiveAccount)
                return BadRequest("The account is inactive.");

            if (result == enOperationResult.Failed)
                return BadRequest("The withdrawal operation failed.");

            return Ok(result);
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer(clsTransferDto dto)
        {
            enOperationResult result =
                await clsTransaction.TransferAsync(
                    dto.AccountID,
                    dto.DestinationAccountID,
                    dto.Amount,
                    dto.EmployeeID);

            if (result == enOperationResult.NoPermission)
                return BadRequest("You do not have permission to transfer.");

            if (result == enOperationResult.AccountNotFound)
                return BadRequest(
                    "The source or destination account was not found.");

            if (result == enOperationResult.InvalidOperation)
                return BadRequest(
                    "Invalid transfer operation. " +
                    "The amount must be greater than zero and the source and destination accounts must be different.");

            if (result == enOperationResult.InActiveAccount)
                return BadRequest(
                    "The source or destination account is inactive.");

            if (result == enOperationResult.Failed)
                return BadRequest("The transfer operation failed.");

            return Ok(result);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            DataTable dt =
                await clsTransaction.GetAllTransactionsAsync();

            List<clsTransactionDto> transactions =
                new List<clsTransactionDto>();

            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(
                    clsTransactionMapper.MapToDto(row));
            }

            return Ok(transactions);
        }
    }
}
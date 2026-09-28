using Atlantis_Bank_API.DTOs.Transaction;
using Atlantis_Bank_API.Mappers;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Deposit")]
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(clsDepositDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            enOperationResult result =
                await clsTransaction.DepositAsync(
                    dto.AccountID,
                    dto.Amount,
                    dto.EmployeeID);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "Deposit failed (no permission). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("You do not have permission to deposit.");
            }

            if (result == enOperationResult.AccountNotFound)
            {
                _logger.LogWarning(
                    "Deposit failed (account not found). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("Account not found.");
            }

            if (result == enOperationResult.InvalidOperation)
            {
                _logger.LogWarning(
                    "Deposit failed (invalid operation). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("Invalid deposit operation.");
            }

            if (result == enOperationResult.InActiveAccount)
            {
                _logger.LogWarning(
                    "Deposit failed (inactive account). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("The account is inactive.");
            }

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "Deposit failed (unexpected error). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("The deposit operation failed.");
            }

            _logger.LogInformation(
                "Deposit succeeded. Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, EmployeeID={EmployeeID}, IP={IP}",
                actorId, actorName, dto.AccountID, dto.Amount, dto.EmployeeID, ip);

            return Ok(result);
        }

        [Authorize(Policy = "Withdrawal")]
        [HttpPost("Withdrawal")]
        public async Task<IActionResult> Withdrawal(clsWithdrawalDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            enOperationResult result =
                await clsTransaction.WithdrawalAsync(
                    dto.AccountID,
                    dto.Amount,
                    dto.EmployeeID);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "Withdrawal failed (no permission). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("You do not have permission to withdraw.");
            }

            if (result == enOperationResult.AccountNotFound)
            {
                _logger.LogWarning(
                    "Withdrawal failed (account not found). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("Account not found.");
            }

            if (result == enOperationResult.InvalidOperation)
            {
                _logger.LogWarning(
                    "Withdrawal failed (invalid operation). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest(
                    "Invalid withdrawal operation. " +
                    "The amount must be greater than zero and cannot exceed the account balance.");
            }

            if (result == enOperationResult.InActiveAccount)
            {
                _logger.LogWarning(
                    "Withdrawal failed (inactive account). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("The account is inactive.");
            }

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "Withdrawal failed (unexpected error). Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.Amount, ip);

                return BadRequest("The withdrawal operation failed.");
            }

            _logger.LogInformation(
                "Withdrawal succeeded. Actor={ActorId}/{ActorName}, AccountID={AccountID}, Amount={Amount}, EmployeeID={EmployeeID}, IP={IP}",
                actorId, actorName, dto.AccountID, dto.Amount, dto.EmployeeID, ip);

            return Ok(result);
        }

        [Authorize(Policy = "Transfer")]
        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer(clsTransferDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            enOperationResult result =
                await clsTransaction.TransferAsync(
                    dto.AccountID,
                    dto.DestinationAccountID,
                    dto.Amount,
                    dto.EmployeeID);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "Transfer failed (no permission). Actor={ActorId}/{ActorName}, SourceAccount={SourceAccount}, DestAccount={DestAccount}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.DestinationAccountID, dto.Amount, ip);

                return BadRequest("You do not have permission to transfer.");
            }

            if (result == enOperationResult.AccountNotFound)
            {
                _logger.LogWarning(
                    "Transfer failed (account not found). Actor={ActorId}/{ActorName}, SourceAccount={SourceAccount}, DestAccount={DestAccount}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.DestinationAccountID, dto.Amount, ip);

                return BadRequest(
                    "The source or destination account was not found.");
            }

            if (result == enOperationResult.InvalidOperation)
            {
                _logger.LogWarning(
                    "Transfer failed (invalid operation). Actor={ActorId}/{ActorName}, SourceAccount={SourceAccount}, DestAccount={DestAccount}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.DestinationAccountID, dto.Amount, ip);

                return BadRequest(
                    "Invalid transfer operation. " +
                    "The amount must be greater than zero and the source and destination accounts must be different.");
            }

            if (result == enOperationResult.InActiveAccount)
            {
                _logger.LogWarning(
                    "Transfer failed (inactive account). Actor={ActorId}/{ActorName}, SourceAccount={SourceAccount}, DestAccount={DestAccount}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.DestinationAccountID, dto.Amount, ip);

                return BadRequest(
                    "The source or destination account is inactive.");
            }

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "Transfer failed (unexpected error). Actor={ActorId}/{ActorName}, SourceAccount={SourceAccount}, DestAccount={DestAccount}, Amount={Amount}, IP={IP}",
                    actorId, actorName, dto.AccountID, dto.DestinationAccountID, dto.Amount, ip);

                return BadRequest("The transfer operation failed.");
            }

            _logger.LogInformation(
                "Transfer succeeded. Actor={ActorId}/{ActorName}, SourceAccount={SourceAccount}, DestAccount={DestAccount}, Amount={Amount}, EmployeeID={EmployeeID}, IP={IP}",
                actorId, actorName, dto.AccountID, dto.DestinationAccountID, dto.Amount, dto.EmployeeID, ip);

            return Ok(result);
        }

        [Authorize(Policy = "Transaction_View")]
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
using AtlantisBank.BLL;
using System.Data;
using System.Threading.Tasks;

public class clsTransaction
{
    public static async Task<enOperationResult> DepositAsync(int accountID, decimal amount, int employeeID)
    {
        if (amount <= 0)
            return enOperationResult.InvalidOperation;

        if (! clsAuthorization.HasPosition("Deposit"))
            return enOperationResult.NoPermission;

        int result = await clsTransactionData.DepositAsync(accountID, amount, employeeID);

        return (enOperationResult)result;
    }

    public static async Task<enOperationResult> WithdrawalAsync(int accountID, decimal amount, int employeeID)
    {
        if (amount <= 0)
            return enOperationResult.InvalidOperation;

        if (!clsAuthorization.HasPosition("Withdrawal"))
            return enOperationResult.NoPermission;

        int result = await clsTransactionData.WithdrawalAsync(accountID, amount, employeeID);

        return (enOperationResult)result;
    }

    public static async Task<enOperationResult> TransferAsync(int accountID, int destinationAccountID, decimal amount, int employeeID)
    {
        if (amount <= 0)
            return enOperationResult.InvalidOperation;

        if (accountID == destinationAccountID)
            return enOperationResult.InvalidOperation;

        if (!clsAuthorization.HasPosition("Transfer"))
            return enOperationResult.NoPermission;

        int result = await clsTransactionData.TransferAsync(accountID, destinationAccountID, amount, employeeID);

        return (enOperationResult)result;
    }

    public static async Task<DataTable> GetAllTransactionsAsync()
    {
        return await clsTransactionData.GetAllTransactionsAsync();
    }
}
using Atlantis_Bank_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class clsTransactionData
{
    public static async Task<int> DepositAsync(int accountID, decimal amount, int employeeID)
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_Deposit", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                SqlParameter returnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                command.Parameters.Add(returnValue);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return (int)returnValue.Value;
            }
        }
    }

    public static async Task<int> WithdrawalAsync(int accountID, decimal amount, int employeeID)
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_Withdrawal", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                SqlParameter returnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                command.Parameters.Add(returnValue);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return (int)returnValue.Value;
            }
        }
    }

    public static async Task<int> TransferAsync(int accountID, int destinationAccountID, decimal amount, int employeeID)
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SP_Transfer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@DestinationAccountID", destinationAccountID);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                SqlParameter returnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                command.Parameters.Add(returnValue);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return (int)returnValue.Value;
            }
        }
    }

    public static async Task<DataTable> GetAllTransactionsAsync()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

        using (SqlCommand command = new SqlCommand("SP_GetAllTransactions", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                dt.Load(reader);
            }
        }

        return dt;
    }
}
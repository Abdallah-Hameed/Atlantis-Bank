using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Atlantis_Bank_DAL
{
    public class clsAccountData
    {
        public static int AddNewAccount(int PersonID, int BranchID, int AccountTypeID)
        {
            int AccountID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_AddAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);

                command.Parameters.AddWithValue("@BranchID", BranchID);

                command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

                SqlParameter outputIdParam = new SqlParameter("@NewAccountID", SqlDbType.Int);

                outputIdParam.Direction = ParameterDirection.Output;

                command.Parameters.Add(outputIdParam);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    AccountID = Convert.ToInt32(outputIdParam.Value);
                }

                catch (SqlException ex)
                {
                    throw new Exception("Error: " + ex.Message, ex);
                }
            }

            return AccountID;
        }

        public static bool GetAccountByID(int AccountID, ref int PersonID, ref int BranchID, ref string AccountNumber,
            ref int AccountTypeID, ref decimal Balance, ref DateTime OpenDate, ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetAccountByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", AccountID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        PersonID = (int)reader["PersonID"];

                        BranchID = (int)reader["BranchID"];

                        AccountNumber = (string)reader["AccountNumber"];

                        AccountTypeID = (int)reader["AccountTypeID"];

                        Balance = (decimal)reader["Balance"];

                        OpenDate = (DateTime)reader["OpenDate"];

                        IsActive = (bool)reader["IsActive"];
                    }
                }
            }

            return isFound;
        }

        public static async Task<DataTable> GetAllAccountsAsync()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetAllAccounts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }

        public static bool UpdateAccount(int AccountID, int BranchID, bool IsActive)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_UpdateAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", AccountID);

                command.Parameters.AddWithValue("@BranchID", BranchID);

                command.Parameters.AddWithValue("@IsActive", IsActive);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }

        public static bool IsAccountExists(int AccountID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetAccountByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", AccountID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    isFound = reader.Read();
                }
            }

            return isFound;
        }

        public static bool DeleteAccount(int AccountID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_DeleteAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", AccountID);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }

        public static async Task<decimal?> GetBalanceAsync(int accountID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAccountBalance", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", accountID);

                    await connection.OpenAsync();

                    object result = await command.ExecuteScalarAsync();

                    if (result == null || result == DBNull.Value)
                        return null;

                    return Convert.ToDecimal(result);
                }
            }
        }
    }
}
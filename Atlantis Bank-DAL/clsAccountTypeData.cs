using System;
using System.Data;
using System.Data.SqlClient;

namespace Atlantis_Bank_DAL
{
    public class clsAccountTypeData
    {
        public static bool GetAccountTypeByID(int AccountTypeID, ref string AccountTypeDescription)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAccountTypeByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;

                            AccountTypeDescription = reader["AccountTypeDescription"].ToString();
                        }

                        reader.Close();
                    }
                    catch
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }

        public static bool UpdateAccountTypeDescription(int AccountTypeID, string AccountTypeDescription)
        {
            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateAccountTypeDescription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

                    command.Parameters.AddWithValue("@AccountTypeDescription", AccountTypeDescription);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        IsUpdated = (result != null && Convert.ToInt32(result) > 0);
                    }
                    catch
                    {
                        IsUpdated = false;
                    }
                }
            }

            return IsUpdated;
        }
    }
}

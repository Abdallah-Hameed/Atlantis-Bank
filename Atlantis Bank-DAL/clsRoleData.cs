using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Atlantis_Bank_DAL
{
    public class clsRoleData
    {
        public static async Task <DataTable> GetAllRoles()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetAllRoles", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }

        public static bool GetRoleByRoleID(int RoleID, ref string RoleDescription)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetRoleByRoleID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;

                            RoleDescription = reader["RoleDescription"].ToString();
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
    }
}
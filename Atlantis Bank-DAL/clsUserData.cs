using Atlantis_Bank_DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AtlantisBank.DAL
{
    public class clsUserData
    {
        public static bool AddNewUser(int EmployeeID, string UserName, string Password, int RoleID, ref int NewUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

                using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    command.Parameters.AddWithValue("@UserName", UserName);

                    command.Parameters.AddWithValue("@Password", Password);

                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    SqlParameter paramNewUserID = new SqlParameter("@NewUserID", SqlDbType.Int);

                    paramNewUserID.Direction = ParameterDirection.Output;

                    command.Parameters.Add(paramNewUserID);

                    connection.Open();

                    command.ExecuteNonQuery();

                    NewUserID = paramNewUserID.Value == DBNull.Value ? -1 : Convert.ToInt32(paramNewUserID.Value);
                }

                return NewUserID != -1;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static bool GetUserInfoByID(int UserID,ref string UserName,ref string Password,ref bool Active,ref int RoleID,ref int EmployeeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

                using (SqlCommand command = new SqlCommand("SP_GetUserByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            UserName = (string)reader["UserName"];

                            Password = (string)reader["Password"];

                            Active = (bool)reader["Active"];

                            RoleID = (int)reader["RoleID"];

                            EmployeeID = (int)reader["EmployeeID"];
                        }
                    }
                }

                return IsFound;
            }

            catch(Exception)
            {
                throw;
            }
        }

        public static bool GetUserInfoByUserName(string UserName, ref int UserID, ref string Password, ref bool Active, ref int RoleID, ref int EmployeeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

                using (SqlCommand command = new SqlCommand("SP_GetUserByUserName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserName", UserName);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            UserID = (int)reader["UserID"];

                            Password = (string)reader["Password"];

                            Active = (bool)reader["Active"];

                            RoleID = (int)reader["RoleID"];

                            EmployeeID = (int)reader["EmployeeID"];
                        }
                    }
                }

                return IsFound;
            }

            catch(Exception)
            {
                throw;
            }    
        }

        public static bool UpdateUser(int UserID, string UserName, bool Active, int RoleID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

                using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.Parameters.AddWithValue("@UserName", UserName);

                    command.Parameters.AddWithValue("@Active", Active);

                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    connection.Open();

                    command.ExecuteNonQuery();

                    return true;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async static Task<DataTable> GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

                using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }

                return dataTable;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static bool DeleteUser(int UserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

                using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();

                    command.ExecuteNonQuery();

                    return true;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static bool ChangePassword(int UserID, string Password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

                using (SqlCommand command = new SqlCommand("SP_ChangePassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.Parameters.AddWithValue("@Password", Password);

                    connection.Open();

                    command.ExecuteNonQuery();

                    return true;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsUserExists(int UserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_IsUserExists", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserID", UserID);

                connection.Open();

                IsFound = Convert.ToBoolean(command.ExecuteScalar());
            }

            return IsFound;
        }
    }
}
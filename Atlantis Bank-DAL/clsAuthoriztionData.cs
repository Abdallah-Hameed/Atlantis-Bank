using Atlantis_Bank_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AtlantisBank.DAL
{
    public class clsAuthorizationData
    {
        public static bool HasPermission(int UserID, string PermissionCode)
        {
            bool HasPermission = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_CheckPermission", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.Parameters.AddWithValue("@PermissionCode", PermissionCode);

                    connection.Open();

                    object Result = command.ExecuteScalar();

                    if (Result != null && Result != DBNull.Value)
                    {
                        HasPermission = Convert.ToInt32(Result) == 1;
                    }
                }
            }

            return HasPermission;
        }

        public static HashSet<string> GetUserPermissions(int UserID)
        {
            HashSet<string> permissions = new HashSet<string>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetUserPermissions", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserID", UserID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        permissions.Add((string)reader["PermissionCode"]);
                    }
                }
            }

            return permissions;
        }

        public static async Task<bool> CheckPositionPermissionAsync(int positionID, string permissionCode)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_CheckPositionPermission", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PositionID", positionID);
                    command.Parameters.AddWithValue("@PermissionCode", permissionCode);

                    SqlParameter returnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(returnValue);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    return (int)returnValue.Value == 1;
                }
            }
        }

        public static HashSet<string> GetPositionPermissions(int PositionID)
        {
            HashSet<string> permissions = new HashSet<string>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetPositionPermissions", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PositionID", PositionID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        permissions.Add((string)reader["PermissionCode"]);
                    }
                }
            }

            return permissions;
        }
    }
}
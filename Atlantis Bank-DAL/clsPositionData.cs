using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Atlantis_Bank_DAL
{
    public class clsPositionData
    {
        public static bool GetPositionByID
        (
            int PositionID, ref string PositionDescription
        )
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetPositionByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PositionID", PositionID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        PositionDescription = (string)reader["PositionDescription"];
                    }
                }
            }

            return isFound;
        }

        public static async Task<DataTable> GetAllPositions()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllPositions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
    }
}
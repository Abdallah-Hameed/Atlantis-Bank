using Atlantis_Bank_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AtlantisBank.DAL
{
    public class clsCountryData
    {
        public static bool GetCountryByID(int CountryID, ref string CountryName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetCountryByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CountryID", CountryID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        CountryName = (string)reader["CountryName"];
                    }
                }
            }

            return isFound;
        }

        public static async Task <DataTable> GetAllCountries()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetAllCountries", connection))
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
    }
}
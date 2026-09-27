using Atlantis_Bank_DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AtlantisBank.DAL
{
    public class clsPersonData
    {
        public static bool GetPersonByID(
            int PersonID,
            ref string FirstName,
            ref string SecondName,
            ref string LastName,
            ref string NationalNo,
            ref bool Gender,
            ref int CountryID,
            ref DateTime DateOfBirth,
            ref string Address,
            ref string Email,
            ref string Phone,
            ref string ImagePath)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_GetPersonByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IsFound = true;

                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];
                        LastName = (string)reader["LastName"];
                        NationalNo = (string)reader["NationalNo"];
                        Gender = (bool)reader["Gender"];
                        CountryID = (int)reader["CountryID"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        Address = (string)reader["Address"];
                        Email = (string)reader["Email"];
                        Phone = (string)reader["Phone"];

                        ImagePath =
                            reader["ImagePath"] == DBNull.Value
                            ? ""
                            : (string)reader["ImagePath"];
                    }
                }
            }

            return IsFound;
        }
    }
}
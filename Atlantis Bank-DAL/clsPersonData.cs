using Atlantis_Bank_DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AtlantisBank.DAL
{
    public class clsPersonData
    {
        public static int AddNewPerson(
            string FirstName,
            string SecondName,
            string LastName,
            string NationalNo,
            bool Gender,
            int CountryID,
            DateTime DateOfBirth,
            string Address,
            string Email,
            string Phone,
            string ImagePath)
        {
            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_AddPerson", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@CountryID", CountryID);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Phone", Phone);

                command.Parameters.AddWithValue(
                    "@ImagePath",
                    (object)ImagePath ?? DBNull.Value);

                SqlParameter paramNewPersonID =
                    new SqlParameter("@NewPersonID", SqlDbType.Int);

                paramNewPersonID.Direction = ParameterDirection.Output;

                command.Parameters.Add(paramNewPersonID);

                connection.Open();

                command.ExecuteNonQuery();

                return Convert.ToInt32(paramNewPersonID.Value);
            }
        }


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


        public static bool GetPersonByNationalNo(
            string NationalNo,
            ref int PersonID,
            ref string FirstName,
            ref string SecondName,
            ref string LastName,
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
                new SqlCommand("SP_GetPersonByNationalNo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IsFound = true;

                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];
                        LastName = (string)reader["LastName"];
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


        public static bool UpdatePerson(
            int PersonID,
            string FirstName,
            string SecondName,
            string LastName,
            string NationalNo,
            bool Gender,
            int CountryID,
            DateTime DateOfBirth,
            string Address,
            string Email,
            string Phone,
            string ImagePath)
        {
            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_UpdatePerson", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@CountryID", CountryID);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Phone", Phone);

                command.Parameters.AddWithValue(
                    "@ImagePath",
                    (object)ImagePath ?? DBNull.Value);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }


        public static bool IsPersonExists(int PersonID)
        {
            bool Exists = false;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_IsPersonExists", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);

                SqlParameter paramExists =
                    new SqlParameter("@Exists", SqlDbType.Bit);

                paramExists.Direction = ParameterDirection.Output;

                command.Parameters.Add(paramExists);

                connection.Open();

                command.ExecuteNonQuery();

                Exists = Convert.ToBoolean(paramExists.Value);
            }

            return Exists;
        }
    }
}
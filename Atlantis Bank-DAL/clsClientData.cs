using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Atlantis_Bank_DAL
{
    public class clsClientData
    {
        public static int AddNewClient
        (
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
            string ImagePath,
            DateTime RegDate,
            int BranchID
        )
        {
            int ClientID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_AddClient", connection))
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

                command.Parameters.AddWithValue("@ImagePath",
                    (object)ImagePath ?? DBNull.Value);

                command.Parameters.AddWithValue("@RegDate", RegDate);

                command.Parameters.AddWithValue("@BranchID", BranchID);

                command.Parameters.AddWithValue("@IsActive", true);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ClientID = Convert.ToInt32(reader["NewClientID"]);
                        }
                    }
                }

                catch (SqlException ex)
                {
                    throw new Exception("Error: " + ex.Message, ex);
                }
            }

            return ClientID;
        }


        public static bool GetClientByID
        (
            int ClientID,
            ref int PersonID,
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
            ref string ImagePath,
            ref DateTime RegDate,
            ref int BranchID,
            ref bool IsActive
        )
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetClientByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClientID", ClientID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        PersonID = Convert.ToInt32(reader["PersonID"]);

                        FirstName = reader["FirstName"].ToString();

                        SecondName = reader["SecondName"].ToString();

                        LastName = reader["LastName"].ToString();

                        NationalNo = reader["NationalNo"].ToString();

                        Gender = Convert.ToBoolean(reader["Gender"]);

                        CountryID = Convert.ToInt32(reader["CountryID"]);

                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                        Address = reader["Address"].ToString();

                        Email = reader["Email"].ToString();

                        Phone = reader["Phone"].ToString();

                        ImagePath = (reader["ImagePath"] == DBNull.Value)
                            ? ""
                            : reader["ImagePath"].ToString();

                        RegDate = Convert.ToDateTime(reader["RegDate"]);

                        BranchID = Convert.ToInt32(reader["BranchID"]);

                        IsActive = Convert.ToBoolean(reader["IsActive"]);
                    }
                }
            }

            return isFound;
        }


        public static bool GetClientByNationalNo
        (
            string NationalNo,
            ref int ClientID,
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
            ref string ImagePath,
            ref DateTime RegDate,
            ref int BranchID,
            ref bool IsActive
        )
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetClientByNationalNo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        ClientID = Convert.ToInt32(reader["ClientID"]);

                        PersonID = Convert.ToInt32(reader["PersonID"]);

                        FirstName = reader["FirstName"].ToString();

                        SecondName = reader["SecondName"].ToString();

                        LastName = reader["LastName"].ToString();

                        Gender = Convert.ToBoolean(reader["Gender"]);

                        CountryID = Convert.ToInt32(reader["CountryID"]);

                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                        Address = reader["Address"].ToString();

                        Email = reader["Email"].ToString();

                        Phone = reader["Phone"].ToString();

                        ImagePath = (reader["ImagePath"] == DBNull.Value)
                            ? ""
                            : reader["ImagePath"].ToString();

                        RegDate = Convert.ToDateTime(reader["RegDate"]);

                        BranchID = Convert.ToInt32(reader["BranchID"]);

                        IsActive = Convert.ToBoolean(reader["IsActive"]);
                    }
                }
            }

            return isFound;
        }

        public static async Task<DataTable> GetAllClientsAsync()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetAllClients", connection))
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


        public static bool UpdateClient
        (
            int ClientID,
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
            string ImagePath,
            DateTime RegDate,
            int BranchID,
            bool IsActive
        )
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_UpdateClient", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClientID", ClientID);

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

                command.Parameters.AddWithValue("@ImagePath",
                    (object)ImagePath ?? DBNull.Value);

                command.Parameters.AddWithValue("@RegDate", RegDate);

                command.Parameters.AddWithValue("@BranchID", BranchID);

                command.Parameters.AddWithValue("@IsActive", IsActive);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }


        public static bool IsClientExists(int ClientID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_GetClientByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClientID", ClientID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    isFound = reader.Read();
                }
            }

            return isFound;
        }


        public static bool IsClientActive(int ClientID)
        {
            bool isActive = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_Clients_IsActive", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClientID", ClientID);

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    isActive = Convert.ToBoolean(result);
                }
            }

            return isActive;
        }


        public static bool DeleteClient(int ClientID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_DeleteClient", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClientID", ClientID);

                connection.Open();

                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
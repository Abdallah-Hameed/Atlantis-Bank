using Atlantis_Bank_DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AtlantisBank.DAL
{
    public class clsEmployeeData
    {
        public static bool AddNewEmployee(
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
            DateTime HireDate,
            decimal Salary,
            int BranchID,
            int PositionID,
            ref int NewPersonID,
            ref int NewEmployeeID)
        {
            NewPersonID = -1;
            NewEmployeeID = -1;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_AddEmployee", connection))
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

                command.Parameters.AddWithValue("@HireDate", HireDate);
                command.Parameters.AddWithValue("@Salary", Salary);
                command.Parameters.AddWithValue("@BranchID", BranchID);
                command.Parameters.AddWithValue("@PositionID", PositionID);


                SqlParameter paramNewPersonID =
                    new SqlParameter("@NewPersonID", SqlDbType.Int);

                paramNewPersonID.Direction = ParameterDirection.Output;

                command.Parameters.Add(paramNewPersonID);


                SqlParameter paramNewEmployeeID =
                    new SqlParameter("@NewEmployeeID", SqlDbType.Int);

                paramNewEmployeeID.Direction = ParameterDirection.Output;

                command.Parameters.Add(paramNewEmployeeID);


                connection.Open();

                command.ExecuteNonQuery();


                NewPersonID =
                    paramNewPersonID.Value == DBNull.Value
                    ? -1
                    : Convert.ToInt32(paramNewPersonID.Value);

                NewEmployeeID =
                    paramNewEmployeeID.Value == DBNull.Value
                    ? -1
                    : Convert.ToInt32(paramNewEmployeeID.Value);
            }

            return NewEmployeeID != -1;
        }


        public static bool GetEmployeeByID(
            int EmployeeID,
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
            ref DateTime HireDate,
            ref DateTime? ExitDate,
            ref decimal Salary,
            ref int BranchID,
            ref int PositionID,
            ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_GetEmployeeByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

                        HireDate = (DateTime)reader["HireDate"];

                        ExitDate =
                            reader["ExitDate"] == DBNull.Value
                            ? (DateTime?)null
                            : (DateTime)reader["ExitDate"];

                        Salary = (decimal)reader["Salary"];
                        BranchID = (int)reader["BranchID"];
                        PositionID = (int)reader["PositionID"];
                        IsActive = (bool)reader["IsActive"];
                    }
                }
            }

            return IsFound;
        }


        public static bool GetEmployeeByNationalNo(
            string NationalNo,
            ref int EmployeeID,
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
            ref DateTime HireDate,
            ref DateTime? ExitDate,
            ref decimal Salary,
            ref int BranchID,
            ref int PositionID,
            ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_GetEmployeeByNationalNo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IsFound = true;

                        EmployeeID = (int)reader["EmployeeID"];
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

                        HireDate = (DateTime)reader["HireDate"];

                        ExitDate =
                            reader["ExitDate"] == DBNull.Value
                            ? (DateTime?)null
                            : (DateTime)reader["ExitDate"];

                        Salary = (decimal)reader["Salary"];
                        BranchID = (int)reader["BranchID"];
                        PositionID = (int)reader["PositionID"];
                        IsActive = (bool)reader["IsActive"];
                    }
                }
            }

            return IsFound;
        }


        public static async Task<DataTable> GetAllEmployees()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_GetAllEmployees", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                using (SqlDataReader reader =
                    await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }


        public static bool UpdateEmployee(int EmployeeID, string FirstName, string SecondName, string LastName, string NationalNo, bool Gender, 
            int CountryID, DateTime DateOfBirth, string Address, string Email, string Phone, string ImagePath, DateTime HireDate, DateTime? ExitDate,
            decimal Salary, int BranchID, int PositionID, bool IsActive)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_UpdateEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

                command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);

                command.Parameters.AddWithValue("@HireDate", HireDate);

                command.Parameters.AddWithValue("@ExitDate", (object)ExitDate ?? DBNull.Value);

                command.Parameters.AddWithValue("@Salary", Salary);

                command.Parameters.AddWithValue("@BranchID", BranchID);

                command.Parameters.AddWithValue("@PositionID", PositionID);

                command.Parameters.AddWithValue("@IsActive", IsActive);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }


        public static bool DeleteEmployee(int EmployeeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand("SP_DeleteEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                connection.Open();

                object result = command.ExecuteScalar();

                return result != null && Convert.ToInt32(result) == 1;
            }
        }


        public static bool IsEmployeeExists(int EmployeeID)
        {
            bool Exists = false;

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))

            using (SqlCommand command =
                new SqlCommand("SP_IsEmployeeExists", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
                {
                    Exists = Convert.ToBoolean(Result);
                }
            }

            return Exists;
        }
    }
}
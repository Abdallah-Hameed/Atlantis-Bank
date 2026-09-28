using Atlantis_Bank_API.DTOs.Employee;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public static class clsEmployeeMapper
    {
        public static IEnumerable<clsEmployeeListDto> Map(DataTable dt)
        {
            List<clsEmployeeListDto> employees = new List<clsEmployeeListDto>();

            foreach (DataRow row in dt.Rows)
            {
                employees.Add(new clsEmployeeListDto
                {
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),

                    NationalNo = row["NationalNo"].ToString(),

                    FirstName = row["FirstName"].ToString(),

                    LastName = row["LastName"].ToString(),

                    Age = Convert.ToInt32(row["Age"]),

                    GenderText = row["GenderText"].ToString(),

                    Phone = row["Phone"].ToString(),

                    CountryName = row["CountryName"].ToString(),

                    BranchName = row["BranchName"].ToString(),

                    Position = row["Position"].ToString(),

                    SystemAccount = row["SystemAccount"].ToString(),

                    Role = row["Role"].ToString(),

                    HireDate = Convert.ToDateTime(row["HireDate"])
                });
            }

            return employees;
        }

        public static clsEmployeeDto Map(clsEmployee employee)
        {
            return new clsEmployeeDto
            {
                EmployeeID = employee.EmployeeID,

                FirstName = employee.PersonInfo.FirstName,
                SecondName = employee.PersonInfo.SecondName,
                LastName = employee.PersonInfo.LastName,

                NationalNo = employee.PersonInfo.NationalNo,
                Gender = employee.PersonInfo.Gender,

                CountryID = employee.PersonInfo.CountryInfo.CountryID,
                DateOfBirth = employee.PersonInfo.DateOfBirth,

                Address = employee.PersonInfo.Address,
                Email = employee.PersonInfo.Email,
                Phone = employee.PersonInfo.Phone,
                ImagePath = employee.PersonInfo.ImagePath,

                BranchID = employee.BranchInfo.BranchID,
                PositionID = employee.PositionInfo.PositionID,

                HireDate = employee.HireDate,
                ExitDate = employee.ExitDate,

                Salary = employee.Salary,
                IsActive = employee.IsActive
            };
        }

        public static void MapToEmployee(clsAddEmployeeDto dto, clsEmployee employee)
        {
            employee.PersonInfo.FirstName = dto.FirstName;
            employee.PersonInfo.SecondName = dto.SecondName;
            employee.PersonInfo.LastName = dto.LastName;

            employee.PersonInfo.NationalNo = dto.NationalNumber;
            employee.PersonInfo.Gender = dto.Gender;

            employee.PersonInfo.CountryInfo = clsCountry.Find(dto.CountryID);

            employee.PersonInfo.DateOfBirth = dto.DateOfBirth;

            employee.PersonInfo.Address = dto.Address;
            employee.PersonInfo.Email = dto.Email;
            employee.PersonInfo.Phone = dto.Phone;
            employee.PersonInfo.ImagePath = dto.ImagePath;

            employee.BranchInfo = clsBranch.Find(dto.BranchID);
            employee.PositionInfo = clsPosition.Find(dto.PositionID);

            employee.HireDate = dto.HireDate;
            employee.ExitDate = dto.ExitDate;

            employee.Salary = dto.Salary;

            employee.IsActive = dto.IsActive;
        }
    }
}
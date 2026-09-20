using Atlantis_Bank_BLL;
using AtlantisBank.DAL;
using System;
using System.Data;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace AtlantisBank.BLL
{
    public class clsEmployee
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode { get; set; }

        public int EmployeeID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public clsBranch BranchInfo { get; set; }

        public clsPosition PositionInfo { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }


        public clsEmployee()
        {
            Mode = enMode.AddNew;

            EmployeeID = -1;

            PersonInfo = new clsPerson();

            PersonInfo.DateOfBirth = DateTime.Now.AddYears(-25);

            HireDate = DateTime.Today;

            ExitDate = null;

            Salary = 0;

            BranchInfo = new clsBranch();

            PositionInfo = new clsPosition();

            IsActive = true;
        }


        private clsEmployee(int EmployeeID, clsPerson Person, DateTime HireDate, DateTime? ExitDate, decimal Salary, int BranchID, int PositionID, bool IsActive)
        {
            Mode = enMode.Update;

            this.EmployeeID = EmployeeID;

            this.PersonInfo = Person;

            this.HireDate = HireDate;

            this.ExitDate = ExitDate;

            this.Salary = Salary;

            this.BranchInfo = clsBranch.Find(BranchID);

            this.PositionInfo = clsPosition.Find(PositionID);

            this.IsActive = IsActive;
        }


        private bool _AddNewEmployee()
        {
            int NewPersonID = -1;

            int NewEmployeeID = -1;

            bool IsAdded = clsEmployeeData.AddNewEmployee(PersonInfo.FirstName, PersonInfo.SecondName, PersonInfo.LastName, PersonInfo.NationalNo,
                PersonInfo.Gender, PersonInfo.CountryInfo.CountryID, PersonInfo.DateOfBirth, PersonInfo.Address, PersonInfo.Email, PersonInfo.Phone,
                PersonInfo.ImagePath, HireDate, Salary, BranchInfo.BranchID, PositionInfo.PositionID, ref NewPersonID, ref NewEmployeeID);

            if (!IsAdded)
                return false;

            PersonInfo.PersonID = NewPersonID;

            EmployeeID = NewEmployeeID;

            return true;
        }


        private bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(EmployeeID, PersonInfo.FirstName, PersonInfo.SecondName, PersonInfo.LastName, PersonInfo.NationalNo,
                PersonInfo.Gender, PersonInfo.CountryInfo.CountryID, PersonInfo.DateOfBirth, PersonInfo.Address, PersonInfo.Email, PersonInfo.Phone,
                PersonInfo.ImagePath, HireDate, ExitDate, Salary, BranchInfo.BranchID, PositionInfo.PositionID, IsActive);
        }


        public enOperationResult Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (!clsAuthorization.HasPermission("Employee_Add"))
                        return enOperationResult.NoPermission;

                    if (Find(PersonInfo.NationalNo) != null)
                        return enOperationResult.AlreadyExists;

                    if (_AddNewEmployee())
                    {
                        Mode = enMode.Update;

                        return enOperationResult.Success;
                    }

                    return enOperationResult.Failed;


                case enMode.Update:

                    if (!clsAuthorization.HasPermission("Employee_Edit"))
                        return enOperationResult.NoPermission;

                    if (_UpdateEmployee())
                        return enOperationResult.Success;

                    return enOperationResult.Failed;
            }

            return enOperationResult.InvalidOperation;
        }


        public static clsEmployee Find(int EmployeeID)
        {
            int PersonID = -1;

            string FirstName = "";

            string SecondName = "";

            string LastName = "";

            string NationalNo = "";

            bool Gender = false;

            int CountryID = -1;

            DateTime DateOfBirth = DateTime.Now;

            string Address = "";

            string Email = "";

            string Phone = "";

            string ImagePath = "";

            DateTime HireDate = DateTime.Now;

            DateTime? ExitDate = null;

            decimal Salary = 0;

            int BranchID = -1;

            int PositionID = -1;

            bool IsActive = false;

            bool IsFound = clsEmployeeData.GetEmployeeByID(EmployeeID, ref PersonID, ref FirstName, ref SecondName, ref LastName, ref NationalNo,
                ref Gender, ref CountryID, ref DateOfBirth, ref Address, ref Email, ref Phone, ref ImagePath, ref HireDate, ref ExitDate, ref Salary,
                ref BranchID, ref PositionID, ref IsActive);

            if (!IsFound)
                return null;

            clsPerson Person = new clsPerson(PersonID, FirstName, SecondName, LastName, NationalNo, Gender, CountryID, DateOfBirth, Address, Email, Phone, ImagePath);

            return new clsEmployee(EmployeeID, Person, HireDate, ExitDate, Salary, BranchID, PositionID, IsActive);
        }


        public static clsEmployee Find(string NationalNo)
        {
            int EmployeeID = -1;

            int PersonID = -1;

            string FirstName = "";

            string SecondName = "";

            string LastName = "";

            bool Gender = false;

            int CountryID = -1;

            DateTime DateOfBirth = DateTime.Now;

            string Address = "";

            string Email = "";

            string Phone = "";

            string ImagePath = "";

            DateTime? ExitDate = null;

            decimal Salary = 0;

            int BranchID = -1;

            int PositionID = -1;

            bool IsActive = false;

            DateTime HireDate = DateTime.Now;

            bool IsFound = clsEmployeeData.GetEmployeeByNationalNo(NationalNo, ref EmployeeID, ref PersonID, ref FirstName, ref SecondName,
                ref LastName, ref Gender, ref CountryID, ref DateOfBirth, ref Address, ref Email, ref Phone, ref ImagePath, ref HireDate,
                ref ExitDate, ref Salary, ref BranchID, ref PositionID, ref IsActive);

            if (!IsFound)
                return null;

            clsPerson Person = new clsPerson(PersonID, FirstName, SecondName, LastName, NationalNo, Gender, CountryID, DateOfBirth, Address, Email, Phone, ImagePath);

            return new clsEmployee(EmployeeID, Person, HireDate, ExitDate, Salary, BranchID, PositionID, IsActive);
        }


        public static async Task<DataTable> GetAllEmployees()
        {
            if (!clsAuthorization.HasPermission("Employee_View"))
                return new DataTable();

            return await clsEmployeeData.GetAllEmployees();
        }


        public static enOperationResult DeleteEmployee(int EmployeeID)
        {
            if (!clsAuthorization.HasPermission("Employee_Delete"))
                return enOperationResult.NoPermission;

            if (!clsEmployeeData.IsEmployeeExists(EmployeeID))
                return enOperationResult.NotFound;

            if (clsEmployeeData.DeleteEmployee(EmployeeID))
                return enOperationResult.Success;

            return enOperationResult.Failed;
        }


        public static bool IsEmployeeExists(int EmployeeID)
        {
            return clsEmployeeData.IsEmployeeExists(EmployeeID);
        }
    }
}
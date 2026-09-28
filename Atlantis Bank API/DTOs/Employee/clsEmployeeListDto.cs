namespace Atlantis_Bank_API.DTOs.Employee
{
    public class clsEmployeeListDto
    {
        public int EmployeeID { get; set; }

        public string NationalNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string GenderText { get; set; }

        public string Phone { get; set; }

        public string CountryName { get; set; }

        public string BranchName { get; set; }

        public string Position { get; set; }

        public string SystemAccount { get; set; }

        public string Role { get; set; }

        public DateTime HireDate { get; set; }
    }
}
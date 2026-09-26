namespace Atlantis_Bank_API.DTOs
{
    public class clsAddClientDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public bool Gender { get; set; }
        public int CountryID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public int BranchID { get; set; }
    }
}
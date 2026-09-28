namespace Atlantis_Bank_API.DTOs.Client
{
    public class clsClientDto
    {
        public int ClientID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string CountryName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BranchName { get; set; }
        public string GenderText { get; set; }
    }
}
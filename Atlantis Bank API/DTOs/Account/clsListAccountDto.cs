namespace Atlantis_Bank_API.DTOs
{
    public class clsListAccountDto
    {
        public int AccountID { get; set; }

        public int PersonID { get; set; }

        public int BranchID { get; set; }

        public string AccountNumber { get; set; }

        public int AccountTypeID { get; set; }

        public decimal Balance { get; set; }

        public DateTime OpenDate { get; set; }

    }
}
namespace Atlantis_Bank_API.DTOs.Transaction
{
    public class clsDepositDto
    {
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeID { get; set; }
    }

    public class clsWithdrawalDto
    {
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeID { get; set; }
    }

    public class clsTransferDto
    {
        public int AccountID { get; set; }
        public int DestinationAccountID { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeID { get; set; }
    }

    public class clsTransactionDto
    {
        public int TransactionID { get; set; }
        public string TransactionType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int EmployeeID { get; set; }
    }
}
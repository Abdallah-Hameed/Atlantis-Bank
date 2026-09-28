using Atlantis_Bank_API.DTOs.Transaction;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public class clsTransactionMapper
    {
        public static clsTransactionDto MapToDto(DataRow row)
        {
            return new clsTransactionDto
            {
                TransactionID = Convert.ToInt32(row["TransactionID"]),
                TransactionType = row["TransactionType"].ToString(),
                From = row["From"].ToString(),
                To = row["To"] == DBNull.Value ? null : row["To"].ToString(),
                Amount = Convert.ToDecimal(row["Amount"]),
                TransactionDate = Convert.ToDateTime(row["TransactionDate"]),
                EmployeeID = Convert.ToInt32(row["EmployeeID"])
            };
        }
    }
}
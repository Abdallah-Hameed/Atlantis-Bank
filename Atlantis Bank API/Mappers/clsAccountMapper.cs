using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_BLL;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public static class clsAccountMapper
    {
        public static clsAccountDto ToDTO(clsAccount account)
        {
            if (account == null)
                return null;

            return new clsAccountDto
            {
                AccountID = account.AccountID,
                PersonID = account.PersonInfo.PersonID,
                BranchID = account.BranchInfo.BranchID,
                AccountNumber = account.AccountNumber,
                AccountTypeID = account.AccountType.AccountTypeID,
                Balance = account.Balance,
                OpenDate = account.OpenDate,
                IsActive = account.IsActive
            };
        }

        public static List<clsListAccountDto> ToDTOList(DataTable dt)
        {
            List<clsListAccountDto> accounts = new List<clsListAccountDto>();

            foreach (DataRow row in dt.Rows)
            {
                accounts.Add(new clsListAccountDto
                {
                    AccountID = (int)row["AccountID"],
                    PersonID = (int)row["PersonID"],
                    BranchID = (int)row["BranchID"],
                    AccountNumber = (string)row["AccountNumber"],
                    AccountTypeID = (int)row["AccountTypeID"],
                    Balance = (decimal)row["Balance"],
                    OpenDate = (DateTime)row["OpenDate"],
                });
            }

            return accounts;
        }

        public static void MapToAccount(clsAddAccountDto dto, clsAccount account)
        {
            account.PersonInfo.PersonID = dto.PersonID;
            account.BranchInfo.BranchID = dto.BranchID;
            account.AccountType.AccountTypeID = dto.AccountTypeID;
        }

        public static void MapToAccount(clsUpdateAccountDto dto, clsAccount account)
        {
            account.BranchInfo.BranchID = dto.BranchID;
            account.IsActive = dto.IsActive;
        }
    }
}
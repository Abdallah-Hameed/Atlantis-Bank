using System;
using System.Data;
using System.Threading.Tasks;
using Atlantis_Bank_DAL;
using AtlantisBank.BLL;

namespace Atlantis_Bank_BLL
{
    public class clsAccount
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public clsAccountType AccountType { get; set; }

        public int AccountID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public clsBranch BranchInfo { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public DateTime OpenDate { get; set; }

        public bool IsActive { get; set; }


        public clsAccount()
        {
            this.AccountID = -1;

            this.PersonInfo = new clsPerson();

            this.BranchInfo = new clsBranch();

            this.AccountNumber = "";

            this.Balance = 0;

            this.OpenDate = DateTime.Now;

            this.IsActive = true;

            Mode = enMode.AddNew;

            this.AccountType = new clsAccountType();
        }


        private clsAccount(int AccountID, int PersonID, int BranchID, string AccountNumber, int AccountTypeID,
            decimal Balance, DateTime OpenDate, bool IsActive)
        {
            this.AccountID = AccountID;

            this.PersonInfo = clsPerson.Find(PersonID);

            this.BranchInfo = clsBranch.Find(BranchID);

            this.AccountNumber = AccountNumber;

            this.Balance = Balance;

            this.OpenDate = OpenDate;

            this.IsActive = IsActive;

            this.AccountType = clsAccountType.Find(AccountTypeID);

            Mode = enMode.Update;
        }


        private bool _AddNewAccount()
        {
            this.AccountID = clsAccountData.AddNewAccount(this.PersonInfo.PersonID, this.BranchInfo.BranchID, this.AccountType.AccountTypeID);

            return (this.AccountID != -1);
        }


        private bool _UpdateAccount()
        {
            return clsAccountData.UpdateAccount(this.AccountID, this.BranchInfo.BranchID, this.IsActive);
        }


        public static clsAccount Find(int AccountID)
        {
            int PersonID = -1;

            int BranchID = -1;

            string AccountNumber = "";

            int AccountTypeID = -1;

            decimal Balance = 0;

            DateTime OpenDate = DateTime.Now;

            bool IsActive = false;

            bool isFound = clsAccountData.GetAccountByID(AccountID, ref PersonID, ref BranchID, ref AccountNumber,
                ref AccountTypeID, ref Balance, ref OpenDate, ref IsActive);

            if (isFound)
            {
                return new clsAccount(AccountID, PersonID, BranchID, AccountNumber, AccountTypeID,
                     Balance, OpenDate, IsActive);
            }

            return null;
        }


        public enOperationResult Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (!clsAuthorization.HasPermission("Account_Add"))
                        return enOperationResult.NoPermission;

                    if (_AddNewAccount())
                    {
                        Mode = enMode.Update;

                        return enOperationResult.Success;
                    }

                    return enOperationResult.Failed;


                case enMode.Update:

                    if (!clsAuthorization.HasPermission("Account_Edit"))
                        return enOperationResult.NoPermission;

                    if (_UpdateAccount())
                        return enOperationResult.Success;

                    return enOperationResult.Failed;
            }

            return enOperationResult.InvalidOperation;
        }


        public static async Task<DataTable> GetAllAccountsAsync()
        {
            if (!clsAuthorization.HasPermission("Account_View"))
                return new DataTable();

            return await clsAccountData.GetAllAccountsAsync();
        }


        public static enOperationResult Delete(int AccountID)
        {
            if (!clsAuthorization.HasPermission("Account_Delete"))
                return enOperationResult.NoPermission;

            if (!clsAccountData.IsAccountExists(AccountID))
                return enOperationResult.NotFound;

            if (clsAccountData.DeleteAccount(AccountID))
                return enOperationResult.Success;

            return enOperationResult.Failed;
        }


        public static bool IsAccountExists(int AccountID)
        {
            return clsAccountData.IsAccountExists(AccountID);
        }

        public static async Task<decimal?> GetBalanceAsync(int accountID)
        {
            return await clsAccountData.GetBalanceAsync(accountID);
        }
    }
}
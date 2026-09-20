using Atlantis_Bank_DAL;

namespace Atlantis_Bank_BLL
{
    public class clsAccountType
    {
        public int AccountTypeID { get; set; }

        public string AccountTypeDescription { get; set; }

        public clsAccountType()
        {
            this.AccountTypeID = 1;

            this.AccountTypeDescription = string.Empty;
        }

        private clsAccountType(int AccountTypeID, string AccountTypeDescription)
        {
            this.AccountTypeID = AccountTypeID;

            this.AccountTypeDescription = AccountTypeDescription;
        }

        public static clsAccountType Find(int AccountTypeID)
        {
            string AccountTypeDescription = string.Empty;

            bool IsFound = clsAccountTypeData.GetAccountTypeByID(AccountTypeID, ref AccountTypeDescription);

            if (IsFound)
            {
                return new clsAccountType(AccountTypeID, AccountTypeDescription);
            }

            return null;
        }

        private bool _UpdateAccountType()
        {
            return clsAccountTypeData.UpdateAccountTypeDescription(this.AccountTypeID, this.AccountTypeDescription);
        }

        public bool Save()
        {
            return _UpdateAccountType();
        }
    }
}

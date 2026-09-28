using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_BLL;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public static class clsAccountTypeMapper
    {
        public static clsAccountTypeDTO ToDTO(clsAccountType accountType)
        {
            if (accountType == null)
                return null;

            return new clsAccountTypeDTO
            {
                AccountTypeID = accountType.AccountTypeID,
                AccountTypeDescription = accountType.AccountTypeDescription
            };
        }

        public static List<clsAccountTypeDTO> ToDTOList(DataTable dt)
        {
            List<clsAccountTypeDTO> accountTypes = new List<clsAccountTypeDTO>();

            foreach (DataRow row in dt.Rows)
            {
                accountTypes.Add(new clsAccountTypeDTO
                {
                    AccountTypeID = (int)row["AccountTypeID"],
                    AccountTypeDescription = (string)row["AccountTypeDescription"]
                });
            }

            return accountTypes;
        }
    }
}
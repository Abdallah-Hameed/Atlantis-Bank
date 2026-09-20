using Atlantis_Bank_DAL;
using System.Data;
using System.Threading.Tasks;

namespace Atlantis_Bank_BLL
{
    public class clsRole
    {
        public int RoleID { get; set; }

        public string RoleDescription { get; set; }

        public clsRole(int RoleID, string RoleDescription)
        {
            this.RoleID = RoleID;

            this.RoleDescription = RoleDescription;
        }

        public clsRole()
        {
            this.RoleID = -1;

            this.RoleDescription = "";
        }

        public static clsRole Find(int RoleID)
        {
            string RoleDescription = string.Empty;

            bool IsFound = clsRoleData.GetRoleByRoleID(RoleID, ref RoleDescription);

            if (IsFound)
            {
                return new clsRole(RoleID, RoleDescription);
            }

            return null;
        }

        public static async Task<DataTable> GetAllRoles()
        {
            return await clsRoleData.GetAllRoles();
        }
    }
}
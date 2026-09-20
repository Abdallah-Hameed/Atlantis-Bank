using System.Data;
using System.Threading.Tasks;
using Atlantis_Bank_DAL;

namespace Atlantis_Bank_BLL
{
    public class clsBranch
    {
        public int BranchID { get; set; }

        public string BranchName { get; set; }

        public clsBranch()
        {
            this.BranchID = -1;

            this.BranchName = "";
        }

        public clsBranch(int branchID, string branchName)
        {
            BranchID = branchID;

            BranchName = branchName;
        }

        public static async Task <DataTable> GetAllBranches()
        {
            return await clsBranchData.GetAllBranches();
        }

        public static clsBranch Find(int BranchID)
        {
            string BranchName = "";

            if (clsBranchData.GetBranchByID(BranchID, ref BranchName))
            {
                return new clsBranch(BranchID, BranchName);
            }

            return null;
        }
    }
}
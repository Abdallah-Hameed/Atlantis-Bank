using Atlantis_Bank_DAL;
using System.Data;
using System.Threading.Tasks;

namespace Atlantis_Bank_BLL
{
    public class clsPosition
    {
        public int PositionID { get; set; }

        public string PositionDescription { get;  set; }

        public clsPosition(int PositionID, string PositionDescription)
        {
            this.PositionID = PositionID;

            this.PositionDescription = PositionDescription;
        }

        public clsPosition()
        {
            this.PositionID = -1;

            this.PositionDescription = "";
        }

        public static clsPosition Find(int PositionID)
        {
            string PositionDescription = "";

            bool isFound = clsPositionData.GetPositionByID(PositionID, ref PositionDescription);

            if (isFound)
            {
                return new clsPosition(PositionID, PositionDescription);
            }

            return null;
        }

        public static async Task<DataTable> GetAllPositions()
        {
            return await clsPositionData.GetAllPositions();
        }
    }
}
using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_BLL;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public static class clsPositionMapper
    {
        public static clsPositionDTO ToDTO(clsPosition position)
        {
            if (position == null)
                return null;

            return new clsPositionDTO
            {
                PositionID = position.PositionID,
                PositionDescription = position.PositionDescription
            };
        }

        public static List<clsPositionDTO> ToDTOList(DataTable dt)
        {
            List<clsPositionDTO> positions = new List<clsPositionDTO>();

            foreach (DataRow row in dt.Rows)
            {
                positions.Add(new clsPositionDTO
                {
                    PositionID = (int)row["PositionID"],
                    PositionDescription = (string)row["PositionDescription"]
                });
            }

            return positions;
        }
    }
}
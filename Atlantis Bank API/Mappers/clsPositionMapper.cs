using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_BLL;
using System.Data;
using System.Collections.Generic;

namespace Atlantis_Bank_API.Mappers
{
    public static class PositionMapper
    {
        public static PositionDTO ToDTO(clsPosition position)
        {
            if (position == null)
                return null;

            return new PositionDTO
            {
                PositionID = position.PositionID,
                PositionDescription = position.PositionDescription
            };
        }

        public static List<PositionDTO> ToDTOList(DataTable dt)
        {
            List<PositionDTO> positions = new List<PositionDTO>();

            foreach (DataRow row in dt.Rows)
            {
                positions.Add(new PositionDTO
                {
                    PositionID = (int)row["PositionID"],
                    PositionDescription = (string)row["PositionDescription"]
                });
            }

            return positions;
        }
    }
}
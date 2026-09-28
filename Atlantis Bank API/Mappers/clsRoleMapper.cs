using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_BLL;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public static class clsRoleMapper
    {
        public static clsRoleDTO ToDTO(clsRole role)
        {
            if (role == null)
                return null;

            return new clsRoleDTO
            {
                RoleID = role.RoleID,
                RoleDescription = role.RoleDescription
            };
        }

        public static List<clsRoleDTO> ToDTOList(DataTable dt)
        {
            List<clsRoleDTO> roles = new List<clsRoleDTO>();

            foreach (DataRow row in dt.Rows)
            {
                roles.Add(new clsRoleDTO
                {
                    RoleID = (int)row["RoleID"],
                    RoleDescription = (string)row["RoleDescription"]
                });
            }

            return roles;
        }
    }
}
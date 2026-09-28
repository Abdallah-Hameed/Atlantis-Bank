using Atlantis_Bank_API.DTOs.User;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public static class clsUserMapper
    {
        public static IEnumerable<clsUserListDto> Map(DataTable dt)
        {
            List<clsUserListDto> users = new List<clsUserListDto>();

            foreach (DataRow row in dt.Rows)
            {
                users.Add(new clsUserListDto
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    UserName = row["UserName"].ToString(),
                    Branch = row["Branch"].ToString(),
                    Position = row["Position"].ToString(),
                    Role = row["Role"].ToString()
                });
            }

            return users;
        }


        public static clsUserDto Map(clsUser user)
        {
            return new clsUserDto
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Active = user.Active,
                RoleID = user.Role.RoleID,
                EmployeeID = user.EmployeeInfo.EmployeeID
            };
        }


        public static void MapToUser(clsAddUserDto dto, clsUser user)
        {
            user.UserName = dto.UserName;
            user.Password = dto.Password;
            user.Active = dto.Active;

            user.Role = clsRole.Find(dto.RoleID);
            user.EmployeeInfo = clsEmployee.Find(dto.EmployeeID);
        }

        public static void MapToUser(clsUpdateUserDto dto, clsUser user)
        {
            user.UserName = dto.UserName;

            user.Active = dto.Active;

            user.Role = clsRole.Find(dto.RoleID);
        }
    }
}
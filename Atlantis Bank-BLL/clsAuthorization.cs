using Atlantis_Bank_BLL;
using AtlantisBank.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlantisBank.BLL
{
    public class clsAuthorization
    {
        public static bool HasPermission(string PermissionCode)
        {
            if (clsCurrentUser.Permissions == null)
                return false;

            return clsCurrentUser.Permissions.Contains(PermissionCode);
        }

        public static HashSet<string> GetPermissionByUserID(int UserID)
        {
            return clsAuthorizationData.GetUserPermissions(UserID);
        }

        public static HashSet<string> GetPositionPermissions(int PositionID)
        {
            return clsAuthorizationData.GetPositionPermissions(PositionID);
        }

        public static bool HasPosition(string PermissionCode)
        {
            if (clsCurrentUser.PositionPermissions == null)
                return false;

            return clsCurrentUser.PositionPermissions.Contains(PermissionCode);
        }
    }
}
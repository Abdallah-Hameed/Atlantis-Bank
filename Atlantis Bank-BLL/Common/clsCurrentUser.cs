using AtlantisBank.BLL;
using System.Collections.Generic;

namespace Atlantis_Bank_BLL
{
    public class clsCurrentUser
    {
        public static clsUser CurrentUser = new clsUser();

        public static HashSet<string> Permissions = new HashSet<string>();

        public static HashSet<string> PositionPermissions = new HashSet<string>();
    }
}
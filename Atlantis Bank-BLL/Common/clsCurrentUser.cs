using System.Collections.Generic;
using System.Threading;

namespace AtlantisBank.BLL
{
    public class clsCurrentUser
    {
        private static readonly AsyncLocal<clsUser> _currentUser = new AsyncLocal<clsUser>();
        private static readonly AsyncLocal<HashSet<string>> _permissions = new AsyncLocal<HashSet<string>>();
        private static readonly AsyncLocal<HashSet<string>> _positionPermissions = new AsyncLocal<HashSet<string>>();

        public static clsUser CurrentUser
        {
            get => _currentUser.Value;
            set => _currentUser.Value = value;
        }

        public static HashSet<string> Permissions
        {
            get => _permissions.Value;
            set => _permissions.Value = value;
        }

        public static HashSet<string> PositionPermissions
        {
            get => _positionPermissions.Value;
            set => _positionPermissions.Value = value;
        }
    }
}
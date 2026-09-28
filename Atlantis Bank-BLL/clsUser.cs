using Atlantis_Bank_BLL;
using AtlantisBank.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AtlantisBank.BLL
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public clsRole Role { get; set; }

        public clsEmployee EmployeeInfo { get; set; }

        public string RefreshTokenHash { get; set; }

        public DateTime? RefreshTokenExpiresAt { get; set; }

        public DateTime? RefreshTokenRevokedAt { get; set; }

        public clsUser()
        {
            Mode = enMode.AddNew;

            UserID = -1;

            UserName = "";

            Password = "";

            Active = true;

            Role = new clsRole();

            EmployeeInfo = new clsEmployee();

            RefreshTokenHash = null;

            RefreshTokenExpiresAt = null;

            RefreshTokenRevokedAt = null;
        }


        private clsUser(int UserID, string UserName, string Password, bool Active, int RoleID, int EmployeeID)
        {
            Mode = enMode.Update;

            this.UserID = UserID;

            this.UserName = UserName;

            this.Password = Password;

            this.Active = Active;

            this.Role = clsRole.Find(RoleID);

            this.EmployeeInfo = clsEmployee.Find(EmployeeID);

            RefreshTokenHash = null;

            RefreshTokenExpiresAt = null;

            RefreshTokenRevokedAt = null;
        }

        private bool _AddNewUser()
        {
            int NewUserID = -1;

            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);

            bool IsAdded = clsUserData.AddNewUser(
                EmployeeInfo.EmployeeID,
                UserName,
                PasswordHash,
                Role.RoleID,
                ref NewUserID);

            if (!IsAdded)
                return false;

            UserID = NewUserID;

            Password = PasswordHash;

            return true;
        }


        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID, UserName, Active, Role.RoleID);
        }


        private enOperationResult _Validate()
        {
            if (Role == null)
                return enOperationResult.RoleNotFound;

            if (EmployeeInfo == null)
                return enOperationResult.EmployeeNotFound;

            return enOperationResult.Success;
        }

        public enOperationResult Save()
        {
            try
            {
                enOperationResult validationResult = _Validate();

                if (validationResult != enOperationResult.Success)
                    return validationResult;

                switch (Mode)
                {
                    case enMode.AddNew:

                        if (FindByUserName(UserName) != null)
                            return enOperationResult.UsernameExists;

                        if (_AddNewUser())
                        {
                            Mode = enMode.Update;

                            return enOperationResult.Success;
                        }

                        return enOperationResult.Failed;

                    case enMode.Update:

                        if (_UpdateUser())
                            return enOperationResult.Success;

                        return enOperationResult.Failed;
                }

                return enOperationResult.InvalidOperation;
            }

            catch (SqlException)
            {
                return enOperationResult.Failed;
            }
        }


        public static clsUser Find(int UserID)
        {
            string UserName = "";

            string Password = "";

            bool Active = false;

            int RoleID = -1;

            int EmployeeID = -1;

            string RefreshTokenHash = null;

            DateTime? RefreshTokenExpiresAt = null;

            DateTime? RefreshTokenRevokedAt = null;

            bool IsFound = clsUserData.GetUserInfoByID(
                UserID,
                ref UserName,
                ref Password,
                ref Active,
                ref RoleID,
                ref EmployeeID,
                ref RefreshTokenHash,
                ref RefreshTokenExpiresAt,
                ref RefreshTokenRevokedAt);

            if (!IsFound)
                return null;

            clsUser user = new clsUser(
                UserID,
                UserName,
                Password,
                Active,
                RoleID,
                EmployeeID);

            user.RefreshTokenHash = RefreshTokenHash;

            user.RefreshTokenExpiresAt = RefreshTokenExpiresAt;

            user.RefreshTokenRevokedAt = RefreshTokenRevokedAt;

            return user;
        }


        public static clsUser FindByUserName(string UserName)
        {
            int UserID = -1;

            string Password = "";

            bool Active = false;

            int RoleID = -1;

            int EmployeeID = -1;

            string RefreshTokenHash = null;

            DateTime? RefreshTokenExpiresAt = null;

            DateTime? RefreshTokenRevokedAt = null;

            bool IsFound = clsUserData.GetUserInfoByUserName(
                UserName,
                ref UserID,
                ref Password,
                ref Active,
                ref RoleID,
                ref EmployeeID,
                ref RefreshTokenHash,
                ref RefreshTokenExpiresAt,
                ref RefreshTokenRevokedAt);

            if (!IsFound)
                return null;

            clsUser user = new clsUser(
                UserID,
                UserName,
                Password,
                Active,
                RoleID,
                EmployeeID);

            user.RefreshTokenHash = RefreshTokenHash;

            user.RefreshTokenExpiresAt = RefreshTokenExpiresAt;

            user.RefreshTokenRevokedAt = RefreshTokenRevokedAt;

            return user;
        }


        public static enOperationResult Delete(int UserID)
        {
            if (!clsUserData.IsUserExists(UserID))
                return enOperationResult.NotFound;

            if (clsUserData.DeleteUser(UserID))
                return enOperationResult.Success;

            return enOperationResult.Failed;
        }


        public async static Task<DataTable> GetAllUsers()
        {
            return await clsUserData.GetAllUsers();
        }


        public enOperationResult ChangePassword(string OldPassword, string NewPassword)
        {
            bool isSelf = (UserID == clsCurrentUser.CurrentUser.UserID);
            bool isSuperAdmin = (clsCurrentUser.CurrentUser.Role.RoleID == 3);

            if (!isSelf && !isSuperAdmin)
                return enOperationResult.NoPermission;

            if (isSelf)
            {
                bool isOldPasswordValid = BCrypt.Net.BCrypt.Verify(OldPassword, this.Password);

                if (!isOldPasswordValid)
                    return enOperationResult.InvalidPassword;
            }

            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(NewPassword);

            if (clsUserData.ChangePassword(UserID, PasswordHash))
            {
                this.Password = PasswordHash;

                return enOperationResult.Success;
            }

            return enOperationResult.Failed;
        }

        public bool SaveRefreshToken(string refreshTokenHash, DateTime expiresAt)
        {
            bool isSaved = clsUserData.UpdateRefreshToken(
                this.UserID,
                refreshTokenHash,
                expiresAt);

            if (isSaved)
            {
                this.RefreshTokenHash = refreshTokenHash;
                this.RefreshTokenExpiresAt = expiresAt;
                this.RefreshTokenRevokedAt = null;
            }

            return isSaved;
        }

        public bool RevokeRefreshToken()
        {
            DateTime revokedAt = DateTime.UtcNow;

            bool isRevoked = clsUserData.RevokeRefreshToken(this.UserID, revokedAt);

            if (isRevoked)
            {
                this.RefreshTokenRevokedAt = revokedAt;
            }

            return isRevoked;
        }
    }
}
using Atlantis_Bank_BLL;
using AtlantisBank.DAL;
using AtlantisBank_BLL;
using System;
using System.Data;
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

        public string PasswordSalt { get; set; }

        public bool Active { get; set; }

        public clsRole Role { get; set; }

        public clsEmployee EmployeeInfo { get; set; }


        public clsUser()
        {
            Mode = enMode.AddNew;

            UserID = -1;

            UserName = "";

            Password = "";

            PasswordSalt = "";

            Active = true;

            Role = new clsRole();

            EmployeeInfo = new clsEmployee();
        }


        private clsUser(int UserID, string UserName, string Password, string PasswordSalt, bool Active, int RoleID, int EmployeeID)
        {
            Mode = enMode.Update;

            this.UserID = UserID;

            this.UserName = UserName;

            this.Password = Password;

            this.PasswordSalt = PasswordSalt;

            this.Active = Active;

            this.Role = clsRole.Find(RoleID);

            this.EmployeeInfo = clsEmployee.Find(EmployeeID);
        }


        private bool _AddNewUser()
        {
            int NewUserID = -1;

            if (EmployeeInfo == null)
                throw new Exception("EmployeeInfo is null.");

            if (Role == null)
                throw new Exception("Role is null.");

            string PasswordHash = "";

            string PasswordSalt = "";

            clsPasswordHasher.HashPassword(Password, out PasswordHash, out PasswordSalt);

            bool IsAdded = clsUserData.AddNewUser(
                EmployeeInfo.EmployeeID,
                UserName,
                PasswordHash,
                PasswordSalt,
                Role.RoleID,
                ref NewUserID);

            if (!IsAdded)
                return false;

            UserID = NewUserID;

            Password = PasswordHash;

            this.PasswordSalt = PasswordSalt;

            return true;
        }


        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID, UserName, Active, Role.RoleID);
        }


        public enOperationResult Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (!clsAuthorization.HasPermission("User_Add"))
                        return enOperationResult.NoPermission;

                    if (FindByUserName(UserName) != null)
                        return enOperationResult.AlreadyExists;

                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;

                        return enOperationResult.Success;
                    }

                    return enOperationResult.Failed;


                case enMode.Update:

                    if (!clsAuthorization.HasPermission("User_Edit"))
                        return enOperationResult.NoPermission;

                    if (_UpdateUser())
                        return enOperationResult.Success;

                    return enOperationResult.Failed;
            }

            return enOperationResult.InvalidOperation;
        }


        public static clsUser Find(int UserID)
        {
            string UserName = "";

            string Password = "";

            string PasswordSalt = "";

            bool Active = false;

            int RoleID = -1;

            int EmployeeID = -1;

            bool IsFound = clsUserData.GetUserInfoByID(
                UserID,
                ref UserName,
                ref Password,
                ref PasswordSalt,
                ref Active,
                ref RoleID,
                ref EmployeeID);

            if (!IsFound)
                return null;

            return new clsUser(
                UserID,
                UserName,
                Password,
                PasswordSalt,
                Active,
                RoleID,
                EmployeeID);
        }


        public static clsUser FindByUserName(string UserName)
        {
            int UserID = -1;

            string Password = "";

            string PasswordSalt = "";

            bool Active = false;

            int RoleID = -1;

            int EmployeeID = -1;

            bool IsFound = clsUserData.GetUserInfoByUserName(
                UserName,
                ref UserID,
                ref Password,
                ref PasswordSalt,
                ref Active,
                ref RoleID,
                ref EmployeeID);

            if (!IsFound)
                return null;

            return new clsUser(
                UserID,
                UserName,
                Password,
                PasswordSalt,
                Active,
                RoleID,
                EmployeeID);
        }


        public static enOperationResult Delete(int UserID)
        {
            if (!clsAuthorization.HasPermission("User_Delete"))
                return enOperationResult.NoPermission;

            if (!clsUserData.IsUserExists(UserID))
                return enOperationResult.NotFound;

            if (clsUserData.DeleteUser(UserID))
                return enOperationResult.Success;

            return enOperationResult.Failed;
        }


        public async static Task<DataTable> GetAllUsers()
        {
            if (!clsAuthorization.HasPermission("User_View"))
                return new DataTable();

            return await clsUserData.GetAllUsers();
        }


        public enOperationResult ChangePassword(string Password)
        {
            if (!clsAuthorization.HasPermission("User_ChangePassword"))
                return enOperationResult.NoPermission;

            string PasswordHash = "";

            string PasswordSalt = "";

            clsPasswordHasher.HashPassword(Password, out PasswordHash, out PasswordSalt);

            if (UserID == clsCurrentUser.CurrentUser.UserID)
            {
                if (clsUserData.ChangePassword(UserID, PasswordHash, PasswordSalt))
                {
                    this.Password = PasswordHash;

                    this.PasswordSalt = PasswordSalt;

                    return enOperationResult.Success;
                }

                return enOperationResult.Failed;
            }

            if (clsCurrentUser.CurrentUser.Role.RoleID < Role.RoleID)
                return enOperationResult.NoPermission;

            if (clsUserData.ChangePassword(UserID, PasswordHash, PasswordSalt))
            {
                this.Password = PasswordHash;

                this.PasswordSalt = PasswordSalt;

                return enOperationResult.Success;
            }

            return enOperationResult.Failed;
        }
    }
}
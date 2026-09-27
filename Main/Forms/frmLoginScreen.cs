using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using AtlantisBank_BLL;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank
{
    public partial class frmLoginScreen : Form
    {
        private const string RegistryKeyPath = @"Software\AtlantisBank";

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                ctrlDonLogin_OnLoginClicked(this, EventArgs.Empty);

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key != null)
                {
                    string savedUsername = key.GetValue("Username", "").ToString();

                    string encryptedPassword = key.GetValue("Password", "").ToString();

                    if (!string.IsNullOrEmpty(savedUsername))
                    {
                        ctrlDonLogin.RememberMe = true;

                        ctrlDonLogin.Username = savedUsername;

                        if (!string.IsNullOrEmpty(encryptedPassword))
                        {
                            ctrlDonLogin.Password = clsUtil.Decrypt(encryptedPassword);
                        }
                    }
                }
            }
        }

        private void ctrlDonLogin_OnLoginClicked(object sender, EventArgs e)
        {
            string username = ctrlDonLogin.Username.Trim();

            string password = ctrlDonLogin.Password.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter username and password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            clsUser User = clsUser.FindByUserName(username);

            if (User == null || !clsPasswordHasher.VerifyPassword(password, User.Password, User.PasswordSalt))
            {
                MessageBox.Show("Invalid username or password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!User.Active)
            {
                MessageBox.Show("Your user account is inactive.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            clsEmployee Employee = clsEmployee.Find(User.EmployeeInfo.EmployeeID);

            if (Employee == null || !Employee.IsActive)
            {
                MessageBox.Show("Your employee account is inactive.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (ctrlDonLogin.RememberMe)
            {
                _SaveRememberedUsername(username, password);
            }
            else
            {
                _ClearRememberedUsername();
            }

            clsCurrentUser.CurrentUser = clsUser.Find(User.UserID);

            clsCurrentUser.Permissions = clsAuthorization.GetPermissionByUserID(User.UserID);

            clsCurrentUser.PositionPermissions = clsAuthorization.GetPositionPermissions(clsCurrentUser.CurrentUser.EmployeeInfo.PositionInfo.PositionID);

            frmDashboard frm = new frmDashboard();

            frm.ShowDialog();
        }

        private void ctrlDonLogin_OnRememberMeChanged(object sender, EventArgs e)
        {
            if (!ctrlDonLogin.RememberMe)
            {
                _ClearRememberedUsername();
            }
        }

        private void ctrlDonLogin_OnForgotPasswordClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact your system administrator to reset your password.", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _SaveRememberedUsername(string username, string password)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue("Username", username);

                key.SetValue("Password", clsUtil.Encrypt(password));
            }
        }

        private void _ClearRememberedUsername()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                if (key != null)
                {
                    key.DeleteValue("Username", false);

                    key.DeleteValue("Password", false);
                }
            }
        }
    }
}
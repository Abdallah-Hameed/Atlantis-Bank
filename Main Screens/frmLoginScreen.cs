using System;
using System.Windows.Forms;
using Microsoft.Win32;
using AtlantisBank.BLL;

namespace Atlantis_Bank
{
    public partial class frmLoginScreen : Form
    {
        private const string RegistryKeyPath = @"Software\AtlantisBank";

        public frmLoginScreen()
        {
            InitializeComponent();
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

            clsEmployee employee = clsEmployee.FindByUserName(username);

            if (employee == null ||  clsUtil.ComputeHash(password) != employee.Password)
            {
                MessageBox.Show("Invalid username or password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            clsUtil.CurrentUser = clsEmployee.Find(employee.UserID);

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
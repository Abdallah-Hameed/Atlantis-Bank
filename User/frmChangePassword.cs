using AtlantisBank.BLL;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank.Employee
{
    public partial class frmChangePassword : Form
    {
        int _UserID = -1;

        clsUser _User = new clsUser();


        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }


        bool _CheckCurrentPassword()
        {
            string CurrentPasswordHash = clsUtil.ComputeHash(txtCurrentPassword.TextButton.Trim());

            return CurrentPasswordHash == _User.Password;
        }


        bool _IsValidNewPassword()
        {
            return txtNewPassword.TextButton.Trim().Length >= 8;
        }


        enOperationResult _SaveNewPasswordInDatabase()
        {
            return _User.ChangePassword(clsUtil.ComputeHash(txtNewPassword.TextButton.Trim()));
        }


        bool _DoPasswordsMatch()
        {
            return txtNewPassword.TextButton == txtConfirmPassword.TextButton;
        }


        void _SaveNewPassword()
        {
            enOperationResult result = _SaveNewPasswordInDatabase();

            switch (result)
            {
                case enOperationResult.Success:

                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                    break;

                case enOperationResult.NoPermission:

                    MessageBox.Show("You do not have permission to change this password.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;

                case enOperationResult.NotFound:

                    MessageBox.Show("User was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;

                case enOperationResult.Failed:

                    MessageBox.Show("Error to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;

                case enOperationResult.InvalidOperation:

                    MessageBox.Show("Invalid operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;
            }
        }


        void _SetNewPassword()
        {
            if (_IsValidNewPassword())
            {
                _SaveNewPassword();
            }

            else
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }


        void _ChangePassword()
        {
            if (_DoPasswordsMatch())
            {
                _SetNewPassword();
            }

            else
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }


        void _Save()
        {
            if (_CheckCurrentPassword())
            {
                _ChangePassword();
            }

            else
            {
                MessageBox.Show("Current password is wrong!", "Wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }


        void _Load()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("User was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.TextButton) || string.IsNullOrEmpty(txtNewPassword.TextButton) || string.IsNullOrEmpty(txtConfirmPassword.TextButton))
            {
                MessageBox.Show("Please fill all fields.", "All fields are required", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Save();
        }


        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _Load();
        }
    }
}
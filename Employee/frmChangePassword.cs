using AtlantisBank.BLL;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank.Employee
{
    public partial class frmChangePassword : Form
    {
        int _UserID = -1;

        clsEmployee _employee = new clsEmployee();

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        bool _CheckCurrentPassword()
        {
            return clsUtil.ComputeHash(txtCurrentPassword.TextButton.Trim()) == _employee.Password;
        }

        bool _IsValidNewPassword()
        {
            return txtNewPassword.TextButton.Trim().Length >= 8;
        }

        bool _SaveNewPasswordInDatabase()
        {
            return _employee.ChangePassword(clsUtil.ComputeHash(txtNewPassword.TextButton.Trim()));
        }

        bool _DoPasswordsMatch()
        {
            return txtNewPassword.TextButton == txtConfirmPassword.TextButton;
        }

        void _SaveNewPassword()
        {
            if (_SaveNewPasswordInDatabase())
            {
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }

            else
            {
                MessageBox.Show("Error to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
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
            _employee = clsEmployee.FindByUserID(_UserID);

            if (_employee == null)
            {
                MessageBox.Show("Employee with userID: " + _UserID.ToString() + " was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.TextButton) || string.IsNullOrEmpty(txtNewPassword.TextButton) || string.IsNullOrEmpty(txtConfirmPassword.TextButton))
            {
                MessageBox.Show("Please fill all fields.", "All fields are required", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Save();
        }
    }
}
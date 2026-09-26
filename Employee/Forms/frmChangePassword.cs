using Atlantis_Bank.Properties;
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

        void _CorrectPassword()
        {
            label1.Enabled = label2.Enabled = label3.Enabled = txtPassword.Enabled = txtConfirmPassword.Enabled = btnSave.Enabled = true;

            btnCheck.Enabled = txtCurrentPassword.Enabled = label7.Enabled = false;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _employee = clsEmployee.FindByUserID(_UserID);

            if (_employee == null)
            {
                MessageBox.Show("Employee with userID: " + _UserID.ToString() + " was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblUsername.Text = _employee.UserName.Trim();

            if (string.IsNullOrEmpty(_employee.PersonInfo.ImagePath))
            {
                if (_employee.PersonInfo.Gender)
                    pbImage.Image = Resources.Female_Employee;

                else
                    pbImage.Image = Resources.Male_Employee1;
            }

            else
                pbImage.ImageLocation = _employee.PersonInfo.ImagePath;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(clsUtil.ComputeHash(txtCurrentPassword.Text) == _employee.Password)
                _CorrectPassword();

            else
            {
                MessageBox.Show("Current password is wrong!","Wrong password",MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

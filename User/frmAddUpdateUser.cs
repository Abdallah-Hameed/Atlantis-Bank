using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank.User
{
    public partial class frmAddUpdateUser : Form
    {
        public delegate void DataBackEventHandler(object sender, int employeeID);

        public event DataBackEventHandler DataBack;

        enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode = enMode.AddNew;

        int _UserID = -1;

        int _EmployeeID = -1;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;

            _UserID = UserID;

            lblID.Text = _UserID.ToString();
        }

        clsEmployee _Employee = new clsEmployee();

        void _LoadEmployee(int EmployeeID)
        {
            _Employee = clsEmployee.Find(EmployeeID);

            if (_Employee != null)
            {
                _EmployeeID = _Employee.EmployeeID;

                lblEmployeeName.Text = _Employee.PersonInfo.FirstName + " " + _Employee.PersonInfo.LastName;

                lblPosition.Text = _Employee.PositionInfo.PositionDescription;

                lblBranch.Text = _Employee.BranchInfo.BranchName;

                lblHireDate.Text = _Employee.HireDate.ToShortDateString();

                pbImage.ImageLocation = _Employee.PersonInfo.ImagePath;
            }

            else
            {
                MessageBox.Show("Employee with ID: " + txtEmployeeID.TextButton + " was not found! Try another ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool _CheckEmployeeID()
        {
            if (string.IsNullOrEmpty(txtEmployeeID.TextButton))
            {
                MessageBox.Show("Please enter Employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (int.Parse(txtEmployeeID.TextButton) < 1)
            {
                MessageBox.Show("Employee ID must be positive! Please try another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        bool _CheckValues()
        {
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrEmpty(txtUserName.TextButton) || string.IsNullOrEmpty(txtPassword.TextButton) || string.IsNullOrEmpty(txtConfirmPassword.TextButton))
                {
                    MessageBox.Show("Please fill all user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                if (txtPassword.TextButton != txtConfirmPassword.TextButton)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            else
            {
                if (string.IsNullOrEmpty(txtUserName.TextButton))
                {
                    MessageBox.Show("Username is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }

        private void _SaveUser()
        {
            if (!_CheckValues())
                return;

            try
            {
                clsUser NewUser;

                if (_Mode == enMode.AddNew)
                {
                    NewUser = new clsUser();

                    NewUser.UserName = txtUserName.TextButton;

                    NewUser.Password = clsUtil.ComputeHash(txtPassword.TextButton);

                    NewUser.EmployeeInfo = _Employee;
                }

                else
                {
                    NewUser = clsUser.Find(_UserID);

                    if (NewUser == null)
                    {
                        MessageBox.Show("User is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    NewUser.UserName = txtUserName.TextButton;
                }

                NewUser.Role = clsRole.Find((cmbRole.SelectedIndex + 1));

                enOperationResult result = NewUser.Save();

                switch (result)
                {
                    case enOperationResult.Success:

                        MessageBox.Show("User saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataBack?.Invoke(this, _UserID);

                        Close();

                        break;

                    case enOperationResult.NoPermission:

                        MessageBox.Show("You do not have permission to add or edit users.", "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;

                    case enOperationResult.AlreadyExists:

                        MessageBox.Show("A user with this username already exists.", "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;

                    case enOperationResult.Failed:

                        MessageBox.Show("User was not saved.", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;

                    case enOperationResult.InvalidOperation:

                        MessageBox.Show("Invalid user operation.", "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _GoToNextTab()
        {
            if (tpInfo.SelectedIndex == 0 && string.IsNullOrEmpty(txtEmployeeID.TextButton))
            {
                MessageBox.Show("Please enter Employee ID First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (tpInfo.SelectedIndex < tpInfo.TabCount - 1)
            {
                tpInfo.SelectedIndex++;

                btnPrevious.Enabled = true;

                if (tpInfo.SelectedIndex == tpInfo.TabCount - 1)
                {
                    btnNextSave.TextButton = _UserID == -1 ? "Save" : "Update";
                }

                return;
            }

            _SaveUser();
        }

        private void _GoToPreviousTab()
        {
            if (tpInfo.TabIndex != 0)
                btnNextSave.TextButton = "Next  →";

            if (tpInfo.SelectedIndex > 0)
            {
                tpInfo.SelectedIndex--;

                if (tpInfo.SelectedIndex == 0)
                    btnPrevious.Enabled = false;

                btnNextSave.TextButton = "Next  →";
            }
        }

        void _Search()
        {
            if (!_CheckEmployeeID())
                return;

            _EmployeeID = int.Parse(txtEmployeeID.TextButton);

            _LoadEmployee(_EmployeeID);
        }

        void _LoadUser(int UserID)
        {
            clsUser User = clsUser.Find(UserID);

            if (User != null)
            {
                _Employee = User.EmployeeInfo;

                if (_Employee != null)
                {
                    _LoadEmployee(_Employee.EmployeeID);
                }

                else
                {
                    MessageBox.Show("Employee is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                txtUserName.TextButton = User.UserName;

                txtPassword.Enabled = txtConfirmPassword.Enabled = false;

                cmbRole.SelectedIndex = User.Role.RoleID - 1;
            }

            else
            {
                MessageBox.Show("User is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        void _UpdateMode()
        {
            lblTitle.Text = "Update User";

            lblSubtitle.Text = "Update a system account information";

            _LoadUser(_UserID);

            txtEmployeeID.TextButton = _EmployeeID.ToString();

            txtEmployeeID.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }

        private void btnNextSave_Click(object sender, EventArgs e)
        {
            _GoToNextTab();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _GoToPreviousTab();
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;

            if (_Mode == enMode.Update)
            {
                _UpdateMode();
            }
        }
    }
}
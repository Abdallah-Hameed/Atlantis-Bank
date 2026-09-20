using Atlantis_Bank.Properties;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank
{
    public partial class frmAddUpdateEmployee : Form
    {
        public delegate void DataBackEventHandler(object sender, int employeeID);

        public event DataBackEventHandler DataBack;

        private clsEmployee _employee;

        private int _employeeID = -1;


        public frmAddUpdateEmployee(int employeeID)
        {
            InitializeComponent();

            _employeeID = employeeID;

            _employee = clsEmployee.Find(employeeID);
        }


        public frmAddUpdateEmployee()
        {
            InitializeComponent();
        }


        private async Task _FillComboBoxes()
        {
            DataTable dtCountries = await clsCountry.GetAllCountries();

            cmbCountry.DataSource = dtCountries;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryID";


            DataTable dtBranches = await clsBranch.GetAllBranches();

            cmbBranch.DataSource = dtBranches;
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.ValueMember = "BranchID";


            DataTable dtPositions = await clsPosition.GetAllPositions();

            cmbPosition.DataSource = dtPositions;
            cmbPosition.DisplayMember = "PositionDescription";
            cmbPosition.ValueMember = "PositionID";


            DataTable dtRoles = await clsRole.GetAllRoles();

            cmbRole.DataSource = dtRoles;
            cmbRole.DisplayMember = "RoleDescription";
            cmbRole.ValueMember = "RoleID";
        }


        private bool _HandlePersonImage()
        {
            if (_employee.PersonInfo.ImagePath != pbImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_employee.PersonInfo.ImagePath))
                {
                    try
                    {
                        File.Delete(_employee.PersonInfo.ImagePath);
                    }

                    catch (IOException ex)
                    {
                        MessageBox.Show("Error deleting old image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        clsUtil.CreateEventLog(ex, EventLogEntryType.Error);

                        return false;
                    }
                }


                if (!string.IsNullOrEmpty(pbImage.ImageLocation))
                {
                    string ImagePath = pbImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref ImagePath))
                    {
                        pbImage.ImageLocation = ImagePath;

                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Error copying image file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }


                _employee.PersonInfo.ImagePath = "";
            }


            return true;
        }


        private void _LoadEmployee()
        {
            if (_employee == null)
            {
                MessageBox.Show("Selected employee was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            lblID.Text = _employee.EmployeeID.ToString();

            txtFirstName.TextButton = _employee.PersonInfo.FirstName;

            txtSecondName.TextButton = _employee.PersonInfo.SecondName;

            txtLastName.TextButton = _employee.PersonInfo.LastName;

            txtNationalNo.TextButton = _employee.PersonInfo.NationalNo;


            if (_employee.PersonInfo.Gender)
            {
                rbFemale.Checked = true;

                rbMale.Checked = false;
            }

            else
            {
                rbMale.Checked = true;

                rbFemale.Checked = false;
            }

            dtpDateOfBirth.Value = _employee.PersonInfo.DateOfBirth;


            if (_employee.PersonInfo.CountryInfo != null)
                cmbCountry.SelectedValue = _employee.PersonInfo.CountryInfo.CountryID;


            txtAddress.TextButton = _employee.PersonInfo.Address;

            txtEmail.TextButton = _employee.PersonInfo.Email;

            txtPhone.TextButton = _employee.PersonInfo.Phone;


            if (_employee.BranchInfo != null)
                cmbBranch.SelectedValue = _employee.BranchInfo.BranchID;


            if (_employee.PositionInfo != null)
                cmbPosition.SelectedValue = _employee.PositionInfo.PositionID;


            lblHireDate.Text = _employee.HireDate.ToString("yyyy/MM/dd");

            txtSalary.TextButton = _employee.Salary.ToString("0.00");


            if (!string.IsNullOrEmpty(_employee.PersonInfo.ImagePath))
            {
                pbImage.ImageLocation = _employee.PersonInfo.ImagePath;

                llRemoveImage.Enabled = true;
            }

            else
            {
                if (_employee.PersonInfo.Gender)
                    pbImage.Image = Resources.Female_Employee;

                else
                    pbImage.Image = Resources.Male_Employee1;

                llRemoveImage.Enabled = false;
            }
        }


        public void _SetUserControls(bool EnableStatus)
        {
            txtUserName.Enabled = EnableStatus;

            txtPassword.Enabled = EnableStatus;

            txtConfirmPassword.Enabled = EnableStatus;

            cmbRole.Enabled = EnableStatus;

            cmbAccountStatus.Enabled = EnableStatus;
        }


        private bool _CheckValues()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.TextButton) ||
                string.IsNullOrWhiteSpace(txtLastName.TextButton) ||
                string.IsNullOrWhiteSpace(txtSecondName.TextButton) ||
                string.IsNullOrWhiteSpace(txtNationalNo.TextButton) ||
                string.IsNullOrWhiteSpace(txtEmail.TextButton) ||
                string.IsNullOrWhiteSpace(txtPhone.TextButton) ||
                string.IsNullOrWhiteSpace(txtAddress.TextButton))
            {
                MessageBox.Show("Enter first name, last name, national number, address, email, and phone.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }


            if (cmbCountry.SelectedIndex == -1 || cmbBranch.SelectedIndex == -1 || cmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Select country, branch, and position.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }


            if (string.IsNullOrWhiteSpace(txtSalary.TextButton))
            {
                MessageBox.Show("Enter employee salary.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtSalary.Focus();

                return false;
            }


            if (!decimal.TryParse(txtSalary.TextButton.Trim(), out decimal Salary) || Salary < 0)
            {
                MessageBox.Show("Enter a valid salary.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtSalary.Focus();

                return false;
            }


            if (_employee.Mode == clsEmployee.enMode.AddNew && clsEmployee.Find(txtNationalNo.TextButton.Trim()) != null)
            {
                MessageBox.Show("An employee with this National No. already exists.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNationalNo.Focus();

                return false;
            }


            return true;
        }


        private void _HandleNewEmployee()
        {
            _employee = new clsEmployee();

            _employee.Mode = clsEmployee.enMode.AddNew;


            if (!tpInfo.TabPages.Contains(tpUserInfo))
                tpInfo.TabPages.Add(tpUserInfo);


            if (cmbCountry.Items.Count > 0)
            {
                try
                {
                    cmbCountry.SelectedValue = 168;
                }

                catch
                {
                    cmbCountry.SelectedIndex = 0;
                }
            }


            if (cmbBranch.Items.Count > 0)
                cmbBranch.SelectedIndex = 0;


            if (cmbPosition.Items.Count > 0)
                cmbPosition.SelectedIndex = 0;


            llRemoveImage.Enabled = false;

            rbMale.Checked = true;

            pbImage.Image = Resources.Male_Employee1;

            lblHireDate.Text = DateTime.Today.ToString("yyyy/MM/dd");

            rbHasSystemAccount.Checked = false;

            rbNoSystemAccount.Checked = true;

            txtUserName.TextButton = "";

            txtPassword.TextButton = "";

            txtConfirmPassword.TextButton = "";


            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;


            if (cmbAccountStatus.Items.Count > 0)
                cmbAccountStatus.SelectedIndex = 0;


            txtUserName.Enabled = false;

            txtPassword.Enabled = false;

            txtConfirmPassword.Enabled = false;

            cmbRole.Enabled = false;

            cmbAccountStatus.Enabled = false;
        }


        private void _HandleExistsEmployee()
        {
            lblTitle.Text = "Update Employee";

            btnNextSave.TextButton = "Next  →";


            if (tpInfo.TabPages.Contains(tpUserInfo))
                tpInfo.TabPages.Remove(tpUserInfo);


            _LoadEmployee();
        }


        private void _Load()
        {
            if (_employeeID == -1)
            {
                _HandleNewEmployee();

                return;
            }


            _HandleExistsEmployee();
        }


        private async Task _SetControls()
        {
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-22);

            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-100);


            await _FillComboBoxes();


            if (cmbAccountStatus.Items.Count > 0)
                cmbAccountStatus.SelectedIndex = 0;
        }


        private async Task _LoadForm()
        {
            try
            {
                await _SetControls();

                _Load();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                clsUtil.CreateEventLog(ex, EventLogEntryType.Error);
            }
        }


        private void _FillEmployeeInfo()
        {
            _employee.PersonInfo.FirstName = txtFirstName.TextButton.Trim();

            _employee.PersonInfo.SecondName = txtSecondName.TextButton.Trim();

            _employee.PersonInfo.LastName = txtLastName.TextButton.Trim();

            _employee.PersonInfo.NationalNo = txtNationalNo.TextButton.Trim();

            _employee.PersonInfo.Gender = rbFemale.Checked;

            _employee.PersonInfo.DateOfBirth = dtpDateOfBirth.Value.Date;


            _employee.PersonInfo.CountryInfo.CountryID = Convert.ToInt32(cmbCountry.SelectedValue);

            _employee.PersonInfo.Address = txtAddress.TextButton.Trim();

            _employee.PersonInfo.Email = txtEmail.TextButton.Trim();

            _employee.PersonInfo.Phone = txtPhone.TextButton.Trim();


            _employee.HireDate = _employee.Mode == clsEmployee.enMode.AddNew ? DateTime.Today : _employee.HireDate;

            _employee.Salary = decimal.Parse(txtSalary.TextButton.Trim());

            _employee.BranchInfo.BranchID = Convert.ToInt32(cmbBranch.SelectedValue);

            _employee.PositionInfo.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);


            if (pbImage.ImageLocation != null)
                _employee.PersonInfo.ImagePath = pbImage.ImageLocation;

            else
                _employee.PersonInfo.ImagePath = "";
        }


        private void _GoToNextTab()
        {
            if (tpInfo.SelectedIndex < tpInfo.TabCount - 1)
            {
                tpInfo.SelectedIndex++;

                btnPrevious.Enabled = true;


                if (tpInfo.SelectedIndex == tpInfo.TabCount - 1)
                    btnNextSave.TextButton = "Save";


                return;
            }


            _SaveEmployee();
        }


        private void _GoToPreviousTab()
        {
            if (tpInfo.SelectedIndex > 0)
            {
                tpInfo.SelectedIndex--;


                if (tpInfo.SelectedIndex == 0)
                    btnPrevious.Enabled = false;


                btnNextSave.TextButton = "Next  →";
            }
        }

        private void _SaveEmployee()
        {
            if (!_CheckValues())
                return;


            if (_employeeID == -1 && rbHasSystemAccount.Checked)
            {
                if (string.IsNullOrEmpty(txtUserName.TextButton) || string.IsNullOrEmpty(txtPassword.TextButton) || string.IsNullOrEmpty(txtConfirmPassword.TextButton))
                {
                    MessageBox.Show("Please fill all user fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }


                if (txtPassword.TextButton != txtConfirmPassword.TextButton)
                {
                    MessageBox.Show("Password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }


            _FillEmployeeInfo();


            if (!_HandlePersonImage())
                return;


            try
            {
                enOperationResult employeeResult = _employee.Save();

                switch (employeeResult)
                {
                    case enOperationResult.NoPermission:

                        MessageBox.Show("You do not have permission to add or edit employees.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;

                    case enOperationResult.AlreadyExists:

                        MessageBox.Show("An employee with this National No already exists.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;

                    case enOperationResult.Failed:

                        MessageBox.Show("The employee could not be saved.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;

                    case enOperationResult.InvalidOperation:

                        MessageBox.Show("Invalid employee operation.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                }


                if (_employeeID == -1 && rbHasSystemAccount.Checked)
                {
                    clsUser User = new clsUser();

                    User.EmployeeInfo = _employee;

                    User.UserName = txtUserName.TextButton.Trim();

                    User.Password = clsUtil.ComputeHash(txtPassword.TextButton);

                    User.Active = cmbAccountStatus.SelectedIndex == 0;

                    User.Role.RoleID = Convert.ToInt32(cmbRole.SelectedValue);


                    enOperationResult userResult = User.Save();

                    switch (userResult)
                    {
                        case enOperationResult.NoPermission:

                            MessageBox.Show("The employee was saved, but you do not have permission to create the system account.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;

                        case enOperationResult.AlreadyExists:

                            MessageBox.Show("The employee was saved, but this username already exists.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;

                        case enOperationResult.Failed:

                            MessageBox.Show("The employee was saved, but the system account could not be created.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;

                        case enOperationResult.InvalidOperation:

                            MessageBox.Show("Invalid system account operation.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                    }
                }


                lblID.Text = _employee.EmployeeID.ToString();

                DataBack?.Invoke(this, _employee.EmployeeID);

                MessageBox.Show("Employee saved successfully.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                clsUtil.CreateEventLog(ex, EventLogEntryType.Error);
            }
        }

        private async void frmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            await _LoadForm();
        }


        private void btnNextSave_Click(object sender, EventArgs e)
        {
            _GoToNextTab();
        }


        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tpInfo.TabIndex != 0)
                btnNextSave.TextButton = "Next  →";

            _GoToPreviousTab();
        }


        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openFileDialog1.FileName;

                llRemoveImage.Enabled = true;
            }
        }


        private void rbMale_Click(object sender, EventArgs e)
        {
            if (_employeeID == -1)
            {
                pbImage.Image = Resources.Male_Employee1;
            }

            else
            {
                if (string.IsNullOrEmpty(_employee.PersonInfo.ImagePath))
                    pbImage.Image = Resources.Male_Employee1;
            }


            rbFemale.Checked = false;
        }


        private void rbFemale_Click_1(object sender, EventArgs e)
        {
            if (_employeeID == -1)
            {
                pbImage.Image = Resources.Female_Employee;
            }

            else
            {
                if (string.IsNullOrEmpty(_employee.PersonInfo.ImagePath))
                    pbImage.Image = Resources.Female_Employee;
            }


            rbMale.Checked = false;
        }


        private void llRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;


            if (rbMale.Checked)
                pbImage.Image = Resources.Male_Employee1;

            else
                pbImage.Image = Resources.Female_Employee;


            llRemoveImage.Enabled = false;
        }


        private void rbNoSystemAccount_Click(object sender, EventArgs e)
        {
            _SetUserControls(false);

            rbHasSystemAccount.Checked = false;
        }


        private void rbHasSystemAccount_Click(object sender, EventArgs e)
        {
            _SetUserControls(true);

            rbNoSystemAccount.Checked = false;
        }
    }
}
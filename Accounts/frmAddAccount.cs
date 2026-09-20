using Atlantis_Bank.Employee.Forms;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.Accounts
{
    public partial class frmAddAccount : Form
    {
        private clsClient _client;

        private clsEmployee _employee;

        private int _personID = -1;

        public frmAddAccount()
        {
            InitializeComponent();
        }

        private async Task _LoadBranches()
        {
            DataTable dtBranches = await clsBranch.GetAllBranches();

            cmbBranch.DataSource = dtBranches;

            cmbBranch.DisplayMember = "BranchName";

            cmbBranch.ValueMember = "BranchID";
        }

        private async void frmAddUpdateAccount_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(llOwnerName, "Show Owner Information");

            llOwnerName.Enabled = false;

            lblOpenDate.Text = DateTime.Today.ToShortDateString();

            btnPrevious.Enabled = false;

            btnNextSave.TextButton = "Next  →";

            cmbOwnerType.SelectedIndex = 0;

            _UpdateOwnerLabels();

            cmbAccountType.SelectedIndex = 0;

            cmbStatus.SelectedIndex = 1;

            await _LoadBranches();
        }

        private bool _SearchClient(int ClientID)
        {
            _client = clsClient.Find(ClientID);

            if (_client == null)
            {
                MessageBox.Show("Client is not found! Please try another Client ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!_client.IsActive)
            {
                MessageBox.Show("Client is not active! Please enter another Client ID or call the support team.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            _personID = _client.PersonInfo.PersonID;

            llOwnerName.Enabled = true;

            llOwnerName.Text = "✓ " +  _client.PersonInfo.FirstName + " " + _client.PersonInfo.LastName;

            return true;
        }

        private bool _SearchEmployee(int EmployeeID)
        {
            _employee = clsEmployee.Find(EmployeeID);

            if (_employee == null)
            {
                MessageBox.Show("Employee is not found! Please try another Employee ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!_employee.IsActive)
            {
                MessageBox.Show("Employee is not active! Please enter another Employee ID or call the support team.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            _personID = _employee.PersonInfo.PersonID;

            llOwnerName.Enabled = true;

            llOwnerName.Text = "✓ " + _employee.PersonInfo.FirstName + " " + _employee.PersonInfo.LastName;

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOwnerID.TextButton))
            {
                MessageBox.Show("Please enter the Owner ID first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtOwnerID.Focus();

                return;
            }

            if (!int.TryParse(txtOwnerID.TextButton, out int OwnerID))
            {
                MessageBox.Show("Please enter a valid Owner ID.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtOwnerID.Focus();

                return;
            }

            if (cmbOwnerType.SelectedIndex == 0)
            {
                _SearchClient(OwnerID);
            }

            else
            {
                _SearchEmployee(OwnerID);
            }
        }

        private bool _ValidateOwner()
        {
            if (_personID == -1)
            {
                MessageBox.Show("Please search for a valid active owner first.", "Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool _ValidateAccountInfo()
        {
            if (cmbAccountType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Account Type.", "Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (cmbBranch.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Branch.", "Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void _SaveAccount()
        {
            if (!_ValidateOwner())
                return;

            if (!_ValidateAccountInfo())
                return;

            clsAccount account = new clsAccount();

            account.PersonInfo.PersonID = _personID;

            account.BranchInfo.BranchID = (int)cmbBranch.SelectedValue;

            account.AccountType.AccountTypeID = cmbAccountType.SelectedIndex + 1;

            try
            {
                enOperationResult result = account.Save();

                switch (result)
                {
                    case enOperationResult.Success:

                        lblAccountID.Text = account.AccountID.ToString();

                        lblAccountNumber.Text = account.AccountNumber;

                        MessageBox.Show("Account saved successfully.", "Account",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();

                        break;


                    case enOperationResult.NoPermission:

                        MessageBox.Show("You do not have permission to add accounts.", "Permission Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;


                    case enOperationResult.Failed:

                        MessageBox.Show("The account could not be saved.", "Account",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;


                    case enOperationResult.InvalidOperation:

                        MessageBox.Show("Invalid account operation.", "Account",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _GoToNextTab()
        {
            if (tpInfo.SelectedIndex < tpInfo.TabCount - 1)
            {
                if (!_ValidateOwner())
                    return;

                tpInfo.SelectedIndex++;

                btnPrevious.Enabled = true;

                btnNextSave.TextButton = "Save";

                return;
            }

            _SaveAccount();
        }

        private void _GoToPreviousTab()
        {
            if (tpInfo.SelectedIndex > 0)
            {
                tpInfo.SelectedIndex--;

                btnPrevious.Enabled = tpInfo.SelectedIndex != 0;

                btnNextSave.TextButton = "Next  →";
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _GoToPreviousTab();
        }

        private void _UpdateOwnerLabels()
        {
            if (cmbOwnerType.SelectedIndex == 0)
            {
                label11.Text = "Client Type:";

                lblOwnerID.Text = "Client ID:";
            }

            else
            {
                label11.Text = "Employee Type:";

                lblOwnerID.Text = "Employee ID:";
            }

            llOwnerName.Text = "● Unknown";

            _personID = -1;
        }

        private void cmbOwnerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UpdateOwnerLabels();
        }

        private void btnNextSave_Click_1(object sender, EventArgs e)
        {
            _GoToNextTab();
        }

        private void llOwnerName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(cmbOwnerType.SelectedIndex == 0)
            {
                frmShowClientInfo frm = new frmShowClientInfo(int.Parse(txtOwnerID.TextButton));

                frm.ShowDialog();
            }

            else
            {
                frmShowEmployeeInfo frm = new frmShowEmployeeInfo(int.Parse(txtOwnerID.TextButton));

                frm.ShowDialog();
            }
        }
    }
}
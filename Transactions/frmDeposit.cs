using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.Transactions
{
    public partial class frmDeposit : Form
    {
        clsAccount _Account = new clsAccount();

        public frmDeposit()
        {
            InitializeComponent();
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

        private async Task _Deposit()
        {
            if (string.IsNullOrEmpty(txtAccountID.TextButton))
            {
                MessageBox.Show("Please enter Account ID First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrEmpty(txtDepositAmount.TextButton))
            {
                MessageBox.Show("Please enter Deposit Amount First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!int.TryParse(txtAccountID.TextButton, out int accountID))
            {
                MessageBox.Show("Invalid Account ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!decimal.TryParse(txtDepositAmount.TextButton, out decimal amount))
            {
                MessageBox.Show("Invalid Deposit Amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int employeeID = clsCurrentUser.CurrentUser.EmployeeInfo.EmployeeID;

            enOperationResult result = await clsTransaction.DepositAsync(accountID, amount, employeeID);

            switch (result)
            {
                case enOperationResult.Success:
                    MessageBox.Show("Deposit completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    decimal? newBalance = await clsAccount.GetBalanceAsync(accountID);

                    if (newBalance.HasValue)
                    {
                        lblBalanceAfterDeposit.Text = newBalance.Value.ToString("N2");

                        ctrlAccountInfo1.LoadAccountInfo(accountID);
                    }

                    return;

                case enOperationResult.NoPermission:
                    MessageBox.Show("You do not have permission to perform this operation.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                case enOperationResult.InvalidOperation:
                    MessageBox.Show("Invalid deposit operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                default:
                    MessageBox.Show("Deposit failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
            }
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;

            btnNextSave.Enabled = false;

            btnNextSave.TextButton = "Next  →";
        }

        private async void btnDeposit_Click(object sender, EventArgs e)
        {
            await _Deposit();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAccountID.TextButton))
            {
                MessageBox.Show("Please enter account ID first!", "Account ID is required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(txtAccountID.TextButton, out int accountID))
            {
                MessageBox.Show("Invalid Account ID! Account ID must contain numbers only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Account = clsAccount.Find(accountID);

            if (_Account == null)
            {
                MessageBox.Show("Account is not found!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            ctrlAccountInfo1.LoadAccountInfo(_Account.AccountID);

            lblStatus.Text = _Account.IsActive ? "Active" : "Inactive";

            btnNextSave.Enabled = true;
        }

        private void btnNextSave_Click_1(object sender, EventArgs e)
        {
            if (tpInfo.SelectedIndex == tpInfo.TabCount - 1)
                Close();

            _GoToNextTab();
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            _GoToPreviousTab();
        }
    }
}
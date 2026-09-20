using Atlantis_Bank.Accounts;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.Transactions
{
    public partial class frmTransfer : Form
    {
        clsAccount _SourceAccount = new clsAccount();

        clsAccount _DestinationAccount = new clsAccount();

        public frmTransfer()
        {
            InitializeComponent();
        }

        private void _GoToNextTab()
        {
            if (tpInfo.SelectedIndex == 0)
            {
                if (_SourceAccount == null)
                    return;
            }

            if (tpInfo.SelectedIndex == 1)
            {
                if (_DestinationAccount == null)
                    return;

                if (_SourceAccount.AccountID == _DestinationAccount.AccountID)
                {
                    MessageBox.Show("Source and Destination accounts cannot be the same.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            if (tpInfo.SelectedIndex < tpInfo.TabCount - 1)
            {
                tpInfo.SelectedIndex++;

                btnPrevious.Enabled = true;

                if (tpInfo.SelectedIndex == tpInfo.TabCount - 1)
                    btnNextSave.TextButton = "Save";
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

        private async Task _Transfer()
        {
            if (string.IsNullOrEmpty(txtSourceAccountID.TextButton))
            {
                MessageBox.Show("Please enter Source Account ID First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrEmpty(txtDestinationAccountID.TextButton))
            {
                MessageBox.Show("Please enter Destination Account ID First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrEmpty(txtTransferAmount.TextButton))
            {
                MessageBox.Show("Please enter Transfer Amount First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!int.TryParse(txtSourceAccountID.TextButton, out int sourceAccountID))
            {
                MessageBox.Show("Source Account ID must contain numbers only.", "Invalid Account ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!int.TryParse(txtDestinationAccountID.TextButton, out int destinationAccountID))
            {
                MessageBox.Show("Destination Account ID must contain numbers only.", "Invalid Account ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (sourceAccountID == destinationAccountID)
            {
                MessageBox.Show("Source and Destination accounts cannot be the same.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!decimal.TryParse(txtTransferAmount.TextButton, out decimal amount))
            {
                MessageBox.Show("Invalid Transfer Amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int employeeID = clsCurrentUser.CurrentUser.EmployeeInfo.EmployeeID;

            enOperationResult result = await clsTransaction.TransferAsync(sourceAccountID, destinationAccountID, amount, employeeID);

            switch (result)
            {
                case enOperationResult.Success:
                    MessageBox.Show("Transfer completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    decimal? newSourceBalance = await clsAccount.GetBalanceAsync(sourceAccountID);

                    if (newSourceBalance.HasValue)
                    {
                        lblNewSourceBalance.Text = newSourceBalance.Value.ToString("N2");

                        ctrlSourceAccountInfo.LoadAccountInfo(_SourceAccount.AccountID);
                    }

                    decimal? newDestinationBalance = await clsAccount.GetBalanceAsync(destinationAccountID);

                    if (newDestinationBalance.HasValue)
                    {
                        lblNewDestinationBalance.Text = newDestinationBalance.Value.ToString("N2");

                        ctrlDestinationAccountInfo.LoadAccountInfo(_DestinationAccount.AccountID);
                    }

                    return;

                case enOperationResult.NoPermission:
                    MessageBox.Show("You do not have permission to perform this operation.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                case enOperationResult.InvalidOperation:
                    MessageBox.Show("Invalid transfer operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                default:
                    MessageBox.Show("Transfer failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
            }
        }

        private void btnNextSave_Click(object sender, EventArgs e)
        {
            if (tpInfo.SelectedIndex == tpInfo.TabCount - 1)
                Close();

            _GoToNextTab();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _GoToPreviousTab();
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;

            btnNextSave.Enabled = false;

            btnNextSave.TextButton = "Next  →";

            lblNewSourceBalance.Text = "$ 0";
            lblNewDestinationBalance.Text = "$ 0";
        }

        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            await _Transfer();
        }

        private void btnFindSourceAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceAccountID.TextButton))
            {
                MessageBox.Show("Please enter Source Account ID first!", "Account ID is required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(txtSourceAccountID.TextButton, out int accountID))
            {
                MessageBox.Show("Source Account ID must contain numbers only.", "Invalid Account ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _SourceAccount = clsAccount.Find(accountID);

            if (_SourceAccount == null)
            {
                MessageBox.Show("Source account is not found!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNextSave.Enabled = false;

                return;
            }

            ctrlSourceAccountInfo.LoadAccountInfo(_SourceAccount.AccountID);

            lblSourceAccountStatus.Text = _SourceAccount.IsActive ? "Active" : "Inactive";

            btnNextSave.Enabled = true;
        }

        private void btnFindDestinationAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDestinationAccountID.TextButton))
            {
                MessageBox.Show("Please enter Destination Account ID first!", "Account ID is required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(txtDestinationAccountID.TextButton, out int accountID))
            {
                MessageBox.Show("Destination Account ID must contain numbers only.", "Invalid Account ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _DestinationAccount = clsAccount.Find(accountID);

            if (_DestinationAccount == null)
            {
                MessageBox.Show("Destination account is not found!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNextSave.Enabled = false;

                return;
            }

            ctrlDestinationAccountInfo.LoadAccountInfo(_DestinationAccount.AccountID);

            lblDestinationAccountStatus.Text = _DestinationAccount.IsActive ? "Active" : "Inactive";

            if (_SourceAccount.AccountID == _DestinationAccount.AccountID)
            {
                MessageBox.Show("Source and Destination accounts cannot be the same.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNextSave.Enabled = false;

                return;
            }

            btnNextSave.Enabled = true;
        }
    }
}
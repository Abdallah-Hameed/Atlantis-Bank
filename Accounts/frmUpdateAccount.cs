using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.Accounts
{
    public partial class frmUpdateAccount : Form
    {
        public delegate void DataBackEventHandler(object sender, int accountID);

        public event DataBackEventHandler DataBack;

        clsAccount _Account = new clsAccount();

        public frmUpdateAccount(int AccountID)
        {
            InitializeComponent();

            _Account = clsAccount.Find(AccountID);
        }

        private async Task _LoadBranches()
        {
            DataTable dtBranches = await clsBranch.GetAllBranches();

            cmbBranch.DataSource = dtBranches;

            cmbBranch.DisplayMember = "BranchName";

            cmbBranch.ValueMember = "BranchID";
        }

        async Task _LoadAccount()
        {
            if (_Account == null)
            {
                MessageBox.Show("Account is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
            ctrlAccountInfo1.LoadAccountInfo(_Account.AccountID);

            await _LoadBranches();

            cmbBranch.SelectedValue = _Account.BranchInfo.BranchID;

            cmbStatus.SelectedIndex = (_Account.IsActive) ? 1 : 0;
        }

        void _UpdateAccount()
        {
            _Account.BranchInfo.BranchID = (int)cmbBranch.SelectedValue;

            _Account.IsActive = cmbStatus.SelectedIndex == 1;

            enOperationResult result = _Account.Save();

            switch (result)
            {
                case enOperationResult.Success:

                    DataBack?.Invoke(this, _Account.AccountID);

                    MessageBox.Show("Account updated successfully.", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;


                case enOperationResult.NoPermission:

                    MessageBox.Show("You do not have permission to edit accounts.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;


                case enOperationResult.Failed:

                    MessageBox.Show("The account could not be updated.", "Account", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;


                case enOperationResult.NotFound:

                    MessageBox.Show("Account was not found.", "Account", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;


                case enOperationResult.InvalidOperation:

                    MessageBox.Show("Invalid account operation.", "Account", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }
        }

        private async void frmUpdateAccount_Load(object sender, EventArgs e)
        {
            await _LoadAccount();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _UpdateAccount();
        }
    }
}

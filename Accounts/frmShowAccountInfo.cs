using Atlantis_Bank_BLL;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank.Accounts
{
    public partial class frmShowAccountInfo : Form
    {
        clsAccount _Account = new clsAccount();

        public frmShowAccountInfo(int AccountID)
        {
            InitializeComponent();

            _Account = clsAccount.Find(AccountID);
        }

        void _Load()
        {
            if (_Account != null)
            {
                ctrlAccountInfo1.LoadAccountInfo(_Account.AccountID);

                lblBranchName.Text = _Account.BranchInfo.BranchName;

                lblStatus.Text = (_Account.IsActive) ? "Active" : "Inactive";
            }

            else
            {
                MessageBox.Show("NO");

                return;
            }
        }

        private void fmrShowAccountInfo_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

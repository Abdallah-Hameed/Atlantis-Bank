using Atlantis_Bank.Accounts;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank.Transactions
{
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }

        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            frmAccountManagement frm = new frmAccountManagement();

            frm.ShowDialog();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            frmDeposit frm = new frmDeposit();

            frm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            frmWithdrawal frm = new frmWithdrawal();

            frm.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            frmTransfer frm = new frmTransfer();

            frm.ShowDialog();
        }

        private void btnTransactionsHistory_Click(object sender, EventArgs e)
        {
            frmTransactionsHistory frm = new frmTransactionsHistory();

            frm.ShowDialog();
        }
    }
}

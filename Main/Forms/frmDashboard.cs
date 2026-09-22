using Atlantis_Bank.Accounts;
using Atlantis_Bank.Transactions;
using AtlantisBank.BLL;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        void _SignOut()
        {
            Hide();

            frmLoginScreen frm = new frmLoginScreen();

            frm.ShowDialog();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnExit, "Exit the program");

            btnTransaction.Focus();

            btnClientManagement.Enabled = clsAuthorization.HasPermission("Client_View");

            btnEmployeeManagement.Enabled = clsAuthorization.HasPermission("Employee_View");

            btnUserManagement.Enabled = clsAuthorization.HasPermission("User_View");

            btnAccountManagement.Enabled = clsAuthorization.HasPermission("Account_View");

            btnTransaction.Enabled = clsAuthorization.HasPosition("Transaction_View");
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            frmTransactions frm = new frmTransactions();

            frm.ShowDialog();
        }

        private void btnClientManagement_Click(object sender, EventArgs e)
        {
            frmClientManagement frm = new frmClientManagement();

            frm.ShowDialog();
        }

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            frmEmployeeManagement frm = new frmEmployeeManagement();

            frm.ShowDialog();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _SignOut();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            frmUserManagement frm = new frmUserManagement();

            frm.ShowDialog();
        }

        private void btnAccountManagement_Click(object sender, EventArgs e)
        {
            frmAccountManagement frm = new frmAccountManagement();

            frm.ShowDialog();
        }
    }
}

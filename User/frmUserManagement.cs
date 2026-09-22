using Atlantis_Bank.Employee;
using Atlantis_Bank.User;
using AtlantisBank.BLL;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank
{
    public partial class frmUserManagement : Form
    {
        public frmUserManagement()
        {
            InitializeComponent();
        }

        DataTable dtAllUsers = new DataTable();

        DataTable dt = new DataTable();

        void _SetHeadersAndWidth()
        {
            dgvUsers.Columns[0].HeaderText = "    ID";
            dgvUsers.Columns[0].Width = 60;

            dgvUsers.Columns[1].HeaderText = "Employee ID";
            dgvUsers.Columns[1].Width = 90;

            dgvUsers.Columns[2].HeaderText = "   Username";
            dgvUsers.Columns[2].Width = 130;

            dgvUsers.Columns[3].HeaderText = "    Branch";
            dgvUsers.Columns[3].Width = 188;

            dgvUsers.Columns[4].HeaderText = "   Position";
            dgvUsers.Columns[4].Width = 130;

            dgvUsers.Columns[5].HeaderText = "      Role";
            dgvUsers.Columns[5].Width = 120;
        }

        async Task _Refresh()
        {
            dtAllUsers = await clsUser.GetAllUsers();

            if (dtAllUsers == null || dtAllUsers.Rows.Count == 0)
            {
                dtAllUsers = new DataTable();

                return;
            }

            dt = dtAllUsers.DefaultView.ToTable(false, "UserID", "EmployeeID", "UserName",
                "Branch", "Position", "Role");

            dgvUsers.DataSource = dt;


            if (dgvUsers.ColumnCount > 0)
            {
                _SetHeadersAndWidth();
            }

            lblRecords.Text = "Total Users: " + dgvUsers.Rows.Count.ToString();
        }

        private async void frmUserManagement_Activated(object sender, EventArgs e)
        {
            await _Refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Filter = "";

            switch (cmbFilter.SelectedItem.ToString())
            {
                case "User ID":

                    Filter = "UserID";

                    break;

                case "Employee ID":

                    Filter = "EmployeeID";

                    break;

                case "Username":

                    Filter = "UserName";

                    break;

                case "Branch":

                    Filter = "Branch";

                    break;

                case "Position":

                    Filter = "Position";

                    break;

                case "Role":

                    Filter = "Role";

                    break;

                case "All Users":

                    Filter = "None";

                    break;

                default:

                    Filter = "None";

                    break;
            }

            if (Filter == "None" || txtSearch.Text.Trim() == "")
            {
                dt.DefaultView.RowFilter = "";

                lblRecords.Text = "Total Users: " + dgvUsers.Rows.Count.ToString();

                return;
            }

            if (Filter == "UserID" || Filter == "EmployeeID")
            {
                if (int.TryParse(txtSearch.Text.Trim(), out int ID))
                {
                    dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, ID);
                }

                else
                {
                    dt.DefaultView.RowFilter = "";
                }
            }

            else
            {
                string SearchText = txtSearch.Text.Trim().Replace("'", "''");

                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", Filter, SearchText);
            }

            lblRecords.Text = "Total Users: " + dgvUsers.Rows.Count.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch_TextChanged(null, null);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
                txtSearch.Enabled = false;

                txtSearch.Text = "";
            }

            else
            {
                txtSearch.Enabled = true;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();

            frm.ShowDialog();

            await _Refresh();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _Refresh();
        }

        private async void frmUserManagement_Load_1(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;

            btnAdd.Enabled = clsAuthorization.HasPermission("User_Add");

            btnUpdate.Enabled = clsAuthorization.HasPermission("User_Edit");

            btnDelete.Enabled = clsAuthorization.HasPermission("User_Delete");

            await _Refresh();
        }

        private async void btnShowInfo_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _Refresh();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user first.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                enOperationResult result = clsUser.Delete((int)dgvUsers.CurrentRow.Cells[0].Value);

                switch (result)
                {
                    case enOperationResult.Success:

                        MessageBox.Show("User deleted successfully.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await _Refresh();

                        break;

                    case enOperationResult.NoPermission:

                        MessageBox.Show("You do not have permission to delete users.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;

                    case enOperationResult.NotFound:

                        MessageBox.Show("User not found.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;

                    case enOperationResult.Failed:

                        MessageBox.Show("User could not be deleted.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;

                    case enOperationResult.InvalidOperation:

                        MessageBox.Show("Invalid operation.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }
    }
}
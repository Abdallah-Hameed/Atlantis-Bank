using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atlantis_Bank.Employee.Forms;
using AtlantisBank.BLL;

namespace Atlantis_Bank
{
    public partial class frmEmployeeManagement : Form
    {
        public frmEmployeeManagement()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        void _SetHeadersAndWidth()
        {
            dgvEmployees.Columns[0].HeaderText = " ID";
            dgvEmployees.Columns[0].Width = 50;

            dgvEmployees.Columns[1].HeaderText = "  National No.";
            dgvEmployees.Columns[1].Width = 110;

            dgvEmployees.Columns[2].HeaderText = "  First Name";
            dgvEmployees.Columns[2].Width = 110;

            dgvEmployees.Columns[3].HeaderText = "  Last Name";
            dgvEmployees.Columns[3].Width = 110;

            dgvEmployees.Columns[4].HeaderText = "  Age";
            dgvEmployees.Columns[4].Width = 60;

            dgvEmployees.Columns[5].HeaderText = "    Phone";
            dgvEmployees.Columns[5].Width = 110;

            dgvEmployees.Columns[6].HeaderText = " Country";
            dgvEmployees.Columns[6].Width = 110;

            dgvEmployees.Columns[7].HeaderText = "    Branch";
            dgvEmployees.Columns[7].Width = 150;

            dgvEmployees.Columns[8].HeaderText = "   Position";
            dgvEmployees.Columns[8].Width = 150;

            dgvEmployees.Columns[9].HeaderText = "System Account";
            dgvEmployees.Columns[9].Width = 150;

            dgvEmployees.Columns[10].HeaderText = "      Role";
            dgvEmployees.Columns[10].Width = 100;

            dgvEmployees.Columns[11].HeaderText = "   Hire Date";
            dgvEmployees.Columns[11].DefaultCellStyle.Format = "yyyy/MM/dd";
            dgvEmployees.Columns[11].Width = 110;
        }

        async Task _Refresh()
        {
            dt = await clsEmployee.GetAllEmployees();

            if (dt == null)
            {
                dt = new DataTable();
            }

            dgvEmployees.DataSource = dt;

            if (dgvEmployees.Rows.Count > 0)
            {
                _SetHeadersAndWidth();
            }

            lblRecords.Text = "Total Employees: " + dgvEmployees.Rows.Count.ToString();
        }

        private async void frmEmployeeManagement_Activated_1(object sender, EventArgs e)
        {
            await _Refresh();
        }

        private void dgvEmployees_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvEmployees.CurrentCell = dgvEmployees.Rows[e.RowIndex].Cells[0];
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Filter = "";

            switch (cmbFilter.SelectedItem.ToString())
            {
                case "Employee ID":

                    Filter = "EmployeeID";

                    break;

                case "National No":

                    Filter = "NationalNo";

                    break;

                case "First Name":

                    Filter = "FirstName";

                    break;

                case "Last Name":

                    Filter = "LastName";

                    break;

                case "Phone":

                    Filter = "Phone";

                    break;

                case "Country":

                    Filter = "CountryName";

                    break;

                case "Branch":

                    Filter = "BranchName";

                    break;

                case "Position":

                    Filter = "Position";

                    break;

                case "System Account":

                    Filter = "SystemAccount";

                    break;

                case "Role":

                    Filter = "Role";

                    break;

                case "All Employees":

                    Filter = "None";

                    break;

                default:

                    Filter = "None";

                    break;
            }

            if (Filter == "None" || txtSearch.Text.Trim() == "")
            {
                dt.DefaultView.RowFilter = "";

                lblRecords.Text = "Total Employees: " + dgvEmployees.Rows.Count.ToString();

                return;
            }

            if (Filter == "EmployeeID")
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

            lblRecords.Text = "Total Employees: " + dgvEmployees.Rows.Count.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch_TextChanged(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
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
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee();

            frm.ShowDialog();

            await _Refresh();
        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmAddUpdateEmployee frm = new frmAddUpdateEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _Refresh();
        }

        private void btnShowInfo_Click_1(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmShowEmployeeInfo frm = new frmShowEmployeeInfo((int)dgvEmployees.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are you sure to delete this employee ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (clsEmployee.DeleteEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await _Refresh();
                    }

                    else
                    {
                        MessageBox.Show("The employee could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void frmEmployeeManagement_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;

            await _Refresh();
        }
    }
}
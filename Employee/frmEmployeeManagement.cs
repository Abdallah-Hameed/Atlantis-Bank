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

        DataTable dtAllEmployees = new DataTable();

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

            dgvEmployees.Columns[5].HeaderText = "  Gender";
            dgvEmployees.Columns[5].Width = 80;

            dgvEmployees.Columns[6].HeaderText = "    Phone";
            dgvEmployees.Columns[6].Width = 110;

            dgvEmployees.Columns[7].HeaderText = " Country";
            dgvEmployees.Columns[7].Width = 110;

            dgvEmployees.Columns[8].HeaderText = "    Branch";
            dgvEmployees.Columns[8].Width = 150;

            dgvEmployees.Columns[9].HeaderText = "   Position";
            dgvEmployees.Columns[9].Width = 150;

            dgvEmployees.Columns[10].HeaderText = "System Account";
            dgvEmployees.Columns[10].Width = 150;

            dgvEmployees.Columns[11].HeaderText = "      Role";
            dgvEmployees.Columns[11].Width = 100;

            dgvEmployees.Columns[12].HeaderText = "   Hire Date";
            dgvEmployees.Columns[12].DefaultCellStyle.Format = "yyyy/MM/dd";
            dgvEmployees.Columns[12].Width = 110;
        }

        async Task _Refresh()
        {
            dtAllEmployees = await clsEmployee.GetAllEmployees();

            if (dtAllEmployees == null || dtAllEmployees.Rows.Count == 0)
            {
                dtAllEmployees = new DataTable();

                return;
            }

            dt = dtAllEmployees.DefaultView.ToTable(false, "EmployeeID", "NationalNo", "FirstName", "LastName",
                "Age", "GenderText", "Phone", "CountryName", "BranchName", "Position", "SystemAccount", "Role", "HireDate");

            dgvEmployees.DataSource = dt;

            if (dgvEmployees.ColumnCount > 0)
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
                    enOperationResult result = clsEmployee.DeleteEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value);

                    switch (result)
                    {
                        case enOperationResult.Success:
                            MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await _Refresh();
                            break;

                        case enOperationResult.NoPermission:
                            MessageBox.Show("You do not have permission to delete this employee.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case enOperationResult.NotFound:
                            MessageBox.Show("Employee not found.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case enOperationResult.Failed:
                            MessageBox.Show("The employee could not be deleted.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case enOperationResult.InvalidOperation:
                            MessageBox.Show("Invalid operation.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
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

            btnAdd.Enabled = clsAuthorization.HasPermission("Employee_Add");

            btnUpdate.Enabled = clsAuthorization.HasPermission("Employee_Edit");

            btnDelete.Enabled = clsAuthorization.HasPermission("Employee_Delete");

            await _Refresh();
        }
    }
}
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;

namespace Atlantis_Bank
{
    public partial class frmClientManagement : Form
    {
        public frmClientManagement()
        {
            InitializeComponent();
        }

        DataTable dtAllClients = new DataTable();

        DataTable dt = new DataTable();

        void _SetHeadersAndWidth()
        {
            dgvClients.Columns[0].HeaderText = "    ID";
            dgvClients.Columns[0].Width = 60;

            dgvClients.Columns[1].HeaderText = "  National No";
            dgvClients.Columns[1].Width = 100;

            dgvClients.Columns[2].HeaderText = "  First Name";
            dgvClients.Columns[2].Width = 100;

            dgvClients.Columns[3].HeaderText = " Second Name";
            dgvClients.Columns[3].Width = 120;

            dgvClients.Columns[4].HeaderText = "  Last Name";
            dgvClients.Columns[4].Width = 100;

            dgvClients.Columns[5].HeaderText = "      Age";
            dgvClients.Columns[5].Width = 60;

            dgvClients.Columns[6].HeaderText = " Country";
            dgvClients.Columns[6].Width = 100;

            dgvClients.Columns[7].HeaderText = "    Phone";
            dgvClients.Columns[7].Width = 100;

            dgvClients.Columns[8].HeaderText = "      Email";
            dgvClients.Columns[8].Width = 140;

            dgvClients.Columns[9].HeaderText = "    Branch";
            dgvClients.Columns[9].Width = 188;

            dgvClients.Columns[10].HeaderText = "      Gender";
            dgvClients.Columns[10].Width = 80;
        }

        async Task _Refresh()
        {
            dtAllClients = await clsClient.GetAllClientsAsync();

            dt = dtAllClients.DefaultView.ToTable(false, "ClientID", "NationalNo", "FirstName", "SecondName", "LastName",
                "Age", "CountryName", "Phone", "Email", "BranchName", "GenderText");

            dgvClients.DataSource = dt;

            if (dgvClients.ColumnCount > 0)
            {
                _SetHeadersAndWidth();
            }

            lblRecords.Text = "Total Clients: " + dgvClients.Rows.Count.ToString();

            txtSearch.Text = "";

            cmbFilter.SelectedIndex = 0;
        }

        private async void frmClientManagement_Activated(object sender, EventArgs e)
        {
            await _Refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Filter = "";

            switch (cmbFilter.SelectedItem.ToString())
            {
                case "Client ID":
                    Filter = "ClientID";
                    break;

                case "National No":
                    Filter = "NationalNo";
                    break;

                case "First Name":
                    Filter = "FirstName";
                    break;

                case "Second Name":
                    Filter = "SecondName";
                    break;

                case "Last Name":
                    Filter = "LastName";
                    break;

                case "Email":
                    Filter = "Email";
                    break;

                case "Phone":
                    Filter = "Phone";
                    break;

                case "Gender":
                    Filter = "GenderText";
                    break;

                case "Country":
                    Filter = "CountryName";
                    break;

                case "Branch":
                    Filter = "BranchName";
                    break;

                case "All Clients":
                    Filter = "None";
                    break;

                default:
                    Filter = "None";
                    break;
            }

            if (Filter == "None" || txtSearch.Text.Trim() == "")
            {
                dt.DefaultView.RowFilter = "";

                lblRecords.Text = "Total Clients: " + dgvClients.Rows.Count.ToString();

                return;
            }

            if (Filter == "ClientID")
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

            lblRecords.Text = "Total Clients: " + dgvClients.Rows.Count.ToString();
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
            frmAddUpdateClient frm = new frmAddUpdateClient();

            frm.ShowDialog();

            await _Refresh();
        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Please select a client first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmAddUpdateClient frm = new frmAddUpdateClient((int)dgvClients.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _Refresh();
        }

        private async void btnShowInfo_Click_1(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Please select a client first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmShowClientInfo frm = new frmShowClientInfo((int)dgvClients.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            await _Refresh();
        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Please select a client first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are you sure to delete this client ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    enOperationResult result = clsClient.DeleteClient((int)dgvClients.CurrentRow.Cells[0].Value);

                    switch (result)
                    {
                        case enOperationResult.Success:
                            MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await _Refresh();
                            break;

                        case enOperationResult.NoPermission:
                            MessageBox.Show("You do not have permission to delete this client.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case enOperationResult.NotFound:
                            MessageBox.Show("Client not found.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case enOperationResult.Failed:
                            MessageBox.Show("The client could not be deleted.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case enOperationResult.InvalidOperation:
                            MessageBox.Show("Invalid operation.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void frmClientManagement_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;

            await _Refresh();

            btnAdd.Enabled = clsAuthorization.HasPermission("Client_Add");

            btnUpdate.Enabled = clsAuthorization.HasPermission("Client_Edit");

            btnDelete.Enabled = clsAuthorization.HasPermission("Client_Delete");
        }
    }
}
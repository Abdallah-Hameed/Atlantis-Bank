using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.Accounts
{
    public partial class frmAccountManagement : Form
    {
        DataTable dtAllAccounts = new DataTable();

        DataTable dt = new DataTable();

        public frmAccountManagement()
        {
            InitializeComponent();
        }

        private async void frmAccountManagement_Load(object sender, EventArgs e)
        {
            cmbOwnerType.SelectedIndex = 0;

            cmbFilter.SelectedIndex = 0;

            txtSearch.Enabled = false;

            await _Refresh();

            _ConfigureDataGrid();

            btnAdd.Enabled = clsAuthorization.HasPermission("Account_Add");

            btnUpdate.Enabled = clsAuthorization.HasPermission("Account_Edit");

            btnCloseAccount.Enabled = clsAuthorization.HasPermission("Account_Delete");
        }

        private void _ConfigureDataGrid()
        {
            dgvAccounts.AutoGenerateColumns = true;

            if (dgvAccounts.Columns.Contains("AccountID"))
                dgvAccounts.Columns["AccountID"].HeaderText = "Account ID";

            if (dgvAccounts.Columns.Contains("PersonID"))
                dgvAccounts.Columns["PersonID"].Visible = false;

            if (dgvAccounts.Columns.Contains("BranchID"))
                dgvAccounts.Columns["BranchID"].Visible = false;

            if (dgvAccounts.Columns.Contains("AccountTypeID"))
                dgvAccounts.Columns["AccountTypeID"].Visible = false;

            if (dgvAccounts.Columns.Contains("ClientID"))
                dgvAccounts.Columns["ClientID"].Visible = false;

            if (dgvAccounts.Columns.Contains("EmployeeID"))
                dgvAccounts.Columns["EmployeeID"].Visible = false;

            if (dgvAccounts.Columns.Contains("AccountNumber"))
                dgvAccounts.Columns["AccountNumber"].HeaderText = "Account Number";

            if (dgvAccounts.Columns.Contains("BranchName"))
                dgvAccounts.Columns["BranchName"].HeaderText = "Branch";

            if (dgvAccounts.Columns.Contains("AccountTypeDescription"))
                dgvAccounts.Columns["AccountTypeDescription"].HeaderText = "Account Type";

            if (dgvAccounts.Columns.Contains("OwnerName"))
                dgvAccounts.Columns["OwnerName"].HeaderText = "Owner Name";

            if (dgvAccounts.Columns.Contains("NationalNo"))
                dgvAccounts.Columns["NationalNo"].HeaderText = "National No.";

            if (dgvAccounts.Columns.Contains("OpenDate"))
                dgvAccounts.Columns["OpenDate"].HeaderText = "Open Date";

            if (dgvAccounts.Columns.Contains("Balance"))
                dgvAccounts.Columns["Balance"].HeaderText = "Balance";

            if (dgvAccounts.Columns.Contains("OwnerType"))
                dgvAccounts.Columns["OwnerType"].HeaderText = "Owner Type";
        }

        private void _ApplyFilters()
        {
            if (dt == null)
                return;

            DataView dv = dt.DefaultView;

            string Filter = "";

            if (cmbOwnerType.SelectedIndex == 1)
            {
                Filter += "ClientID IS NOT NULL";
            }

            else if (cmbOwnerType.SelectedIndex == 2)
            {
                Filter += "EmployeeID IS NOT NULL";
            }

            string SearchText = txtSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                switch (cmbFilter.SelectedIndex)
                {
                    case 0:
                        break;

                    case 1:
                        _ApplyAccountIDFilter(ref Filter, SearchText);
                        break;

                    case 2:
                        _ApplyTextFilter(ref Filter, "AccountNumber", SearchText);
                        break;

                    case 3:
                        _ApplyTextFilter(ref Filter, "NationalNo", SearchText);
                        break;

                    case 4:
                        _ApplyTextFilter(ref Filter, "OwnerName", SearchText);
                        break;

                    case 5:
                        _ApplyTextFilter(ref Filter, "AccountTypeDescription", SearchText);
                        break;

                    case 6:
                        _ApplyBalanceFilter(ref Filter, SearchText);
                        break;

                    case 7:
                        _ApplyOpenDateFilter(ref Filter, SearchText);
                        break;
                }
            }

            dv.RowFilter = Filter;

            dgvAccounts.DataSource = dv;
        }

        private void _ApplyAccountIDFilter(ref string Filter, string SearchText)
        {
            _AddAnd(ref Filter);

            if (int.TryParse(SearchText, out int AccountID))
            {
                Filter += $"AccountID = {AccountID}";
            }

            else
            {
                Filter += "1 = 0";
            }
        }

        private void _ApplyTextFilter(ref string Filter, string ColumnName, string SearchText)
        {
            _AddAnd(ref Filter);

            Filter += $"[{ColumnName}] LIKE '%{_EscapeFilterValue(SearchText)}%'";
        }

        private void _ApplyBalanceFilter(ref string Filter, string SearchText)
        {
            _AddAnd(ref Filter);

            if (decimal.TryParse(SearchText, out decimal Balance))
            {
                string Value = Balance.ToString(CultureInfo.InvariantCulture);

                Filter += $"Balance = {Value}";
            }

            else
            {
                Filter += "1 = 0";
            }
        }

        private void _ApplyOpenDateFilter(ref string Filter, string SearchText)
        {
            _AddAnd(ref Filter);

            if (DateTime.TryParse(SearchText, out DateTime OpenDate))
            {
                Filter += $"OpenDate = #{OpenDate:MM/dd/yyyy}#";
            }

            else
            {
                Filter += "1 = 0";
            }
        }

        private void _AddAnd(ref string Filter)
        {
            if (!string.IsNullOrWhiteSpace(Filter))
                Filter += " AND ";
        }

        private string _EscapeFilterValue(string Value)
        {
            return Value.Replace("'", "''");
        }

        private async Task _Refresh()
        {
            dtAllAccounts = await clsAccount.GetAllAccountsAsync();

            if (dtAllAccounts == null || dtAllAccounts.Columns.Count == 0)
            {
                dt = new DataTable();

                dgvAccounts.DataSource = dt;

                return;
            }

            dt = dtAllAccounts.DefaultView.ToTable(false, "AccountID", "PersonID", "BranchID", "AccountTypeID",
                "ClientID", "EmployeeID", "AccountNumber", "BranchName", "AccountTypeDescription", "OwnerName",
                "NationalNo", "OpenDate", "Balance", "OwnerType");

            dgvAccounts.DataSource = dt;

            _ApplyFilters();

            _ConfigureDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ApplyFilters();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            _ApplyFilters();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();

            if (cmbFilter.SelectedIndex == 0)
                txtSearch.Enabled = false;

            else
                txtSearch.Enabled = true;

            _ApplyFilters();
        }

        private void cmbOwnerType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _ApplyFilters();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddAccount frm = new frmAddAccount();

            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow == null)
            {
                MessageBox.Show("Please select an account first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmUpdateAccount frm = new frmUpdateAccount((int)dgvAccounts.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private async void frmAccountManagement_Activated(object sender, EventArgs e)
        {
            await _Refresh();
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow == null)
            {
                MessageBox.Show("Please select an account first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmShowAccountInfo frm = new frmShowAccountInfo((int)dgvAccounts.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private async void btnCloseAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow == null)
            {
                MessageBox.Show("Please select an account first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are you sure you want to close this account?", "Confirm Close Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            enOperationResult result = clsAccount.Delete((int)dgvAccounts.CurrentRow.Cells[0].Value);

            switch (result)
            {
                case enOperationResult.Success:

                    MessageBox.Show("Account closed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await _Refresh();

                    break;


                case enOperationResult.NoPermission:

                    MessageBox.Show("You do not have permission to close accounts.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;


                case enOperationResult.NotFound:

                    MessageBox.Show("Account was not found.", "Account", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    await _Refresh();

                    break;


                case enOperationResult.Failed:

                    MessageBox.Show("Account was not closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;


                case enOperationResult.InvalidOperation:

                    MessageBox.Show("Invalid account operation.", "Account", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }
        }
    }
}
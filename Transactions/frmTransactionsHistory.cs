using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.Transactions
{
    public partial class frmTransactionsHistory : Form
    {
        public frmTransactionsHistory()
        {
            InitializeComponent();
        }

        DataTable dtAllTransactions = new DataTable();

        DataTable dt = new DataTable();

        void _SetHeadersAndWidth()
        {
            dgvTransactions.Columns["TransactionID"].HeaderText = "Transaction ID";
            dgvTransactions.Columns["TransactionType"].HeaderText = "Transaction Type";
            dgvTransactions.Columns["From"].HeaderText = "From";
            dgvTransactions.Columns["To"].HeaderText = "To";
            dgvTransactions.Columns["Amount"].HeaderText = "Amount";
            dgvTransactions.Columns["TransactionDate"].HeaderText = "Transaction Date";
            dgvTransactions.Columns["EmployeeID"].HeaderText = "Employee ID";

            dgvTransactions.Columns["TransactionID"].FillWeight = 80;
            dgvTransactions.Columns["TransactionType"].FillWeight = 110;
            dgvTransactions.Columns["From"].FillWeight = 120;
            dgvTransactions.Columns["To"].FillWeight = 120;
            dgvTransactions.Columns["Amount"].FillWeight = 90;
            dgvTransactions.Columns["TransactionDate"].FillWeight = 140;
            dgvTransactions.Columns["EmployeeID"].FillWeight = 85;

            dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N2";
            dgvTransactions.Columns["TransactionDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
        }

        async Task _Refresh()
        {
            dtAllTransactions = await clsTransaction.GetAllTransactionsAsync();

            dt = dtAllTransactions.DefaultView.ToTable(false,
                "TransactionID",
                "TransactionType",
                "From",
                "To",
                "Amount",
                "TransactionDate",
                "EmployeeID");

            dgvTransactions.DataSource = dt;

            dgvTransactions.ScrollBars = ScrollBars.Both;

            if (dgvTransactions.ColumnCount > 0)
            {
                _SetHeadersAndWidth();
            }

            lblRecords.Text = "Total Transactions: " + dgvTransactions.Rows.Count.ToString();

            txtSearch.Text = "";

            cmbTransactionType.SelectedIndex = 0;

            cmbFilter.SelectedIndex = 0;
        }

        void _ApplyFilter()
        {
            if (dt.Columns.Count == 0)
                return;

            string TransactionTypeFilter = "";
            string SearchFilter = "";

            if (cmbTransactionType.SelectedIndex > 0)
            {
                string TransactionType = cmbTransactionType.SelectedItem.ToString().Replace("'", "''");

                TransactionTypeFilter = string.Format("[TransactionType] = '{0}'", TransactionType);
            }

            if (cmbFilter.SelectedIndex > 0 && txtSearch.Text.Trim() != "")
            {
                string SearchText = txtSearch.Text.Trim().Replace("'", "''");

                switch (cmbFilter.SelectedItem.ToString())
                {
                    case "Transaction ID":

                        if (int.TryParse(SearchText, out int TransactionID))
                        {
                            SearchFilter = string.Format("[TransactionID] = {0}", TransactionID);
                        }

                        break;

                    case "From":

                        if (long.TryParse(SearchText, out long FromAccountNumber))
                        {
                            SearchFilter = string.Format("[From] = {0}", FromAccountNumber);
                        }

                        break;

                    case "To":

                        if (long.TryParse(SearchText, out long ToAccountNumber))
                        {
                            SearchFilter = string.Format("[To] = {0}", ToAccountNumber);
                        }

                        break;

                    case "Amount":

                        if (decimal.TryParse(SearchText, out decimal Amount))
                        {
                            SearchFilter = string.Format("[Amount] = {0}",
                                Amount.ToString(CultureInfo.InvariantCulture));
                        }

                        break;

                    case "Transaction Date":

                        if (DateTime.TryParse(SearchText, out DateTime TransactionDate))
                        {
                            DateTime StartDate = TransactionDate.Date;
                            DateTime EndDate = StartDate.AddDays(1);

                            SearchFilter = string.Format(
                                "[TransactionDate] >= #{0}# AND [TransactionDate] < #{1}#",
                                StartDate.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                                EndDate.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                        }

                        break;

                    case "Employee ID":

                        if (int.TryParse(SearchText, out int EmployeeID))
                        {
                            SearchFilter = string.Format("[EmployeeID] = {0}", EmployeeID);
                        }

                        break;
                }
            }

            string FinalFilter = "";

            if (TransactionTypeFilter != "" && SearchFilter != "")
            {
                FinalFilter = TransactionTypeFilter + " AND " + SearchFilter;
            }
            else if (TransactionTypeFilter != "")
            {
                FinalFilter = TransactionTypeFilter;
            }
            else
            {
                FinalFilter = SearchFilter;
            }

            dt.DefaultView.RowFilter = FinalFilter;

            lblRecords.Text = "Total Transactions: " + dgvTransactions.Rows.Count.ToString();
        }

        private void frmTransactionsHistory_Load(object sender, EventArgs e)
        {

            cmbTransactionType.SelectedIndex = 0;

            cmbFilter.SelectedIndex = 0;

            txtSearch.Enabled = false;
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

            _ApplyFilter();
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private async void frmTransactionsHistory_Activated(object sender, EventArgs e)
        {
            await _Refresh();
        }
    }
}

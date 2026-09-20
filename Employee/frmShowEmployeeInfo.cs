using AtlantisBank.BLL;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank.Employee.Forms
{
    public partial class frmShowEmployeeInfo : Form
    {
        int _EmployeeID = -1;

        public frmShowEmployeeInfo(int EmployeeID)
        {
            InitializeComponent();

            _EmployeeID = EmployeeID;
        }

        void _Load(int EmployeeID)
        {
            clsEmployee employee = clsEmployee.Find(EmployeeID);

            if (employee != null)
            {
                ctrlPersonalContactInfo1.LoadData(employee.PersonInfo.PersonID);

                lblPosition.Text = employee.PositionInfo.PositionDescription;

                lblBranch.Text = employee.BranchInfo.BranchName;
            }

            else
            {
                MessageBox.Show("Employee is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
        }

        private void frmShowEmployeeInfo_Load(object sender, EventArgs e)
        {
            _Load(_EmployeeID);
        }

        private void AddUpdateEmployee_DataBack(object sender, int EmployeeID)
        {
            _EmployeeID = EmployeeID;

            _Load(EmployeeID);
        }

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee(_EmployeeID);

            frm.DataBack += AddUpdateEmployee_DataBack;

            frm.ShowDialog();
        }
    }
}

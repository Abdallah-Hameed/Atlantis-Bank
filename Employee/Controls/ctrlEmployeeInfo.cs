using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System.Windows.Forms;

namespace Atlantis_Bank.Employee.Controls
{
    public partial class ctrlEmployeeInfo : UserControl
    {
        public ctrlEmployeeInfo()
        {
            InitializeComponent();
        }

        public void LoadEmployeeData(int EmployeeID)
        {
            clsEmployee employee = clsEmployee.Find(EmployeeID);

            lblEmployeeName.Text = employee.PersonInfo.FirstName + " " + employee.PersonInfo.LastName;

            //lblPosition.Text = em

            lblBranch.Text = clsBranch.Find(employee.BranchInfo.BranchID).ToString();
        }
    }
}

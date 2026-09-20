using Atlantis_Bank_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.Accounts
{
    public partial class ctrlAccountInfo : UserControl
    {
        public ctrlAccountInfo()
        {
            InitializeComponent();
        }

        public void LoadAccountInfo(int AccountID)
        {
            clsAccount _Account = clsAccount.Find(AccountID);

            lblAccountID.Text = _Account.AccountID.ToString();

            lblAccountNumber.Text = _Account.AccountNumber;

            lblAccountType.Text = _Account.AccountType.AccountTypeDescription;

            lblOwnerName.Text =_Account.PersonInfo.FirstName + " " + _Account.PersonInfo.LastName;

            lblBalance.Text = _Account.Balance.ToString();

            lblOpenDate.Text = _Account.OpenDate.ToShortDateString();
        }
    }
}

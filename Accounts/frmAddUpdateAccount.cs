using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Windows.Forms;

namespace Atlantis_Bank.Accounts
{
    public partial class frmAddUpdateAccount : Form
    {
        clsClient _CLient = new clsClient();

        public frmAddUpdateAccount()
        {
            InitializeComponent();
        }

        bool _IsClientExists(int ClientID)
        {
            return clsClient.IsClientExists(ClientID);
        }

        bool _IsClientActive(int ClientID)
        {
            return clsClient.IsClientActive(ClientID);
        }

        private void frmAddUpdateAccount_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(llClientName, "Show Client Information");

            llClientName.Enabled = false;

            lblOpenDate.Text = DateTime.Today.ToString();

            if(clsCurrentUser.CurrentUser != null)
            {
                lblCreatedUser.Text = clsCurrentUser.CurrentUser.UserName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtClientID.TextButton))
            {
                MessageBox.Show("Please enter the Client ID first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_CLient != null)
            {
                if (_IsClientExists(_CLient.ClientID))
                {
                    if (_IsClientActive(_CLient.ClientID))
                    {
                        llClientName.Text = _CLient.PersonInfo.FirstName + " " + _CLient.PersonInfo.LastName;

                        
                    }

                    else
                    {
                        MessageBox.Show("Client is not active! Please enter another Client ID or call the support team.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }

                else
                {
                    MessageBox.Show("Client is not found! Please try another Client ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            else
            {
                MessageBox.Show("Error loading client data! Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }
    }
}

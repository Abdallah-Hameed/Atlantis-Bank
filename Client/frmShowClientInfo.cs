using System;
using System.Windows.Forms;
using Atlantis_Bank_BLL;

namespace Atlantis_Bank
{
    public partial class frmShowClientInfo : Form
    {
        private int _clientID;

        private clsClient _Client;

        public frmShowClientInfo(int clientID)
        {
            InitializeComponent();

            _clientID = clientID;
        }

        private void _Load(int ClientID)
        {
            _Client = clsClient.Find(ClientID);

            if (_Client == null)
            {
                MessageBox.Show("The selected client was not found.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }

            ctrlPersonalContactInfo1.LoadData(_Client.PersonInfo.PersonID);

            lblBranch.Text = _Client.BranchInfo.BranchName;

            lblID.Text = _Client.ClientID.ToString();
        }

        private void AddUpdateClient_DataBack(object sender, int ClientID)
        {
            _Client.ClientID = ClientID;

            _Load(ClientID);
        }

        private void frmShowClientInfo_Load_1(object sender, EventArgs e)
        {
            _Load(_clientID);
        }

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Client != null)
            {
                frmAddUpdateClient frm = new frmAddUpdateClient(_Client.ClientID);

                frm.DataBack += AddUpdateClient_DataBack;

                frm.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please add client informaion first!", "Client is not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

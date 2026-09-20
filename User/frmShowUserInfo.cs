using AtlantisBank.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank.User
{
    public partial class frmShowUserInfo : Form
    {
        int _UserID = -1;

        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        void _Load(int UserID)
        {
            clsUser User = clsUser.Find(UserID);

            if (User != null)
            {
                ctrlPersonalContactInfo1.LoadData(User.EmployeeInfo.PersonInfo.PersonID);

                lblID.Text = User.UserID.ToString();

                lblUsername.Text = User.UserName;

                lblRole.Text = User.Role.RoleDescription;
            }

            else
            {
                MessageBox.Show("User is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
        }

        private void AddUpdateUser_DataBack(object sender, int UserID)
        {
            _UserID = UserID;

            _Load(UserID);
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            _Load(_UserID);
        }

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateUser frm  = new frmAddUpdateUser(_UserID);

            frm.DataBack += AddUpdateUser_DataBack;

            frm.ShowDialog();
        }
    }
}

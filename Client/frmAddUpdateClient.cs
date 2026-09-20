using Atlantis_Bank.Properties;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantis_Bank
{
    public partial class frmAddUpdateClient : Form
    {
        public delegate void DataBackEventHandler(object sender, int clientID);

        public event DataBackEventHandler DataBack;

        private clsClient _client;

        private int _clientID = -1;

        public frmAddUpdateClient(int clientID)
        {
            InitializeComponent();

            _clientID = clientID;

            _client = clsClient.Find(clientID);
        }

        public frmAddUpdateClient()
        {
            InitializeComponent();
        }

        async Task _FillComboBoxes()
        {
            DataTable dtCountries = await clsCountry.GetAllCountries();

            cmbCountry.DataSource = dtCountries;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryID";


            DataTable dtBranches = await clsBranch.GetAllBranches();

            cmbBranch.DataSource = dtBranches;
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.ValueMember = "BranchID";
        }

        private bool _HandlePersonImage()
        {
            if (_client.PersonInfo.ImagePath != pbImage.ImageLocation) //يعني الصورة تغيرت
            {
                if(!string.IsNullOrEmpty(_client.PersonInfo.ImagePath))
                {
                    try
                    {
                        File.Delete(_client.PersonInfo.ImagePath);
                    }

                    catch (IOException ex)
                    {
                        MessageBox.Show("Error deleting old image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        clsUtil.CreateEventLog(ex, EventLogEntryType.Error);

                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(pbImage.ImageLocation))
                {
                    string ImagePath = pbImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref ImagePath))
                    {
                        pbImage.ImageLocation = ImagePath;

                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Error copying image file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }

                _client.PersonInfo.ImagePath = "";
            }

            return true;
        }

        private void _LoadClient()
        {
            if (_client == null)
            {
                MessageBox.Show("Selected client was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblID.Text = _client.ClientID.ToString();

            txtFirstName.TextButton = _client.PersonInfo.FirstName;

            txtSecondName.TextButton = _client.PersonInfo.SecondName;

            txtLastName.TextButton = _client.PersonInfo.LastName;

            txtNationalNo.TextButton = _client.PersonInfo.NationalNo;

            if (_client.PersonInfo.Gender)
            {
                rbFemale.Checked = true;

                rbMale.Checked = false;
            }

            else
            {
                rbMale.Checked = true;

                rbFemale.Checked = false;
            }

            llRemoveImage.Enabled = (pbImage.ImageLocation != null);

            dtpDateOfBirth.Value = _client.PersonInfo.DateOfBirth;

            cmbCountry.SelectedValue = _client.PersonInfo.CountryInfo.CountryID;

            cmbBranch.SelectedValue = _client.BranchInfo.BranchID;

            txtAddress.TextButton = _client.PersonInfo.Address;

            txtEmail.TextButton = _client.PersonInfo.Email;

            txtPhone.TextButton = _client.PersonInfo.Phone;

            if (!string.IsNullOrEmpty(_client.PersonInfo.ImagePath))
            {
                pbImage.ImageLocation = _client.PersonInfo.ImagePath;

                llRemoveImage.Enabled = true;
            }

            else
            {
                if (_client.PersonInfo.Gender)
                    pbImage.Image = Resources.Female_Employee;
                else
                    pbImage.Image = Resources.Male_Employee1;

                llRemoveImage.Enabled = false;
            }
        }

        bool _CheckValues()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.TextButton) || string.IsNullOrWhiteSpace(txtLastName.TextButton) || string.IsNullOrWhiteSpace(txtSecondName.TextButton) ||
                string.IsNullOrWhiteSpace(txtNationalNo.TextButton) || string.IsNullOrWhiteSpace(txtEmail.TextButton) || string.IsNullOrWhiteSpace(txtPhone.TextButton)
                || string.IsNullOrWhiteSpace(txtAddress.TextButton))
            {
                MessageBox.Show("Enter first name, last name, national number, address, email, and phone.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (_client.Mode == clsClient.enMode.AddNew && clsClient.Find(txtNationalNo.TextButton.Trim()) != null)
            {
                MessageBox.Show("A client with this National No. already exists.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNationalNo.Focus();

                return false;
            }

            return true;
        }

        void _HandleNewClient()
        {
            _client = new clsClient();

            _client.Mode = clsClient.enMode.AddNew;

            if (cmbCountry.Items.Count > 0)
                cmbCountry.SelectedValue = 168;

            if (cmbBranch.Items.Count > 0)
                cmbBranch.SelectedIndex = 0;

            llRemoveImage.Enabled = false;

            rbMale.Checked = true;

            pbImage.Image = Resources.Male_Employee1;
        }

        void _HandleExistsClient()
        {
            lblTitle.Text = "Update Client";

            _LoadClient();
        }

        void _Load()
        {
            txtAddress.Enabled = true;

            if (_clientID == -1)
            {
                _HandleNewClient();

                return;
            }

            _HandleExistsClient();
        }

        async Task _SetControls()
        {
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-22);

            await _FillComboBoxes();
        }

        async Task _LoadForm()
        {
            try
            {
                await _SetControls();

                _Load();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

                clsUtil.CreateEventLog(ex, EventLogEntryType.Error);

                return;
            }
        }

        void _FillClientInfo()
        {
            _client.PersonInfo.FirstName = txtFirstName.TextButton.Trim();

            _client.PersonInfo.SecondName = txtSecondName.TextButton.Trim();

            _client.PersonInfo.LastName = txtLastName.TextButton.Trim();

            _client.PersonInfo.NationalNo = txtNationalNo.TextButton.Trim();

            _client.PersonInfo.Gender = rbFemale.Checked;

            _client.PersonInfo.DateOfBirth = dtpDateOfBirth.Value.Date;

            _client.PersonInfo.CountryInfo.CountryID = (int)cmbCountry.SelectedValue;

            _client.BranchInfo.BranchID= (int)cmbBranch.SelectedValue;

            _client.PersonInfo.Address = txtAddress.TextButton.Trim();

            _client.PersonInfo.Email = txtEmail.TextButton.Trim();

            _client.PersonInfo.Phone = txtPhone.TextButton.Trim();

            _client.RegDate = (_client.Mode == clsClient.enMode.AddNew ? DateTime.Today : _client.RegDate);

            _client.IsActive = true;

            if (pbImage.ImageLocation != null)
                _client.PersonInfo.ImagePath = pbImage.ImageLocation;
            else
                _client.PersonInfo.ImagePath = "";
        }

        void _SaveClient()
        {
            if (!_CheckValues())
                return;

            _FillClientInfo();

            if (!_HandlePersonImage())
                return;

            try
            {
                enOperationResult result = _client.Save();

                switch (result)
                {
                    case enOperationResult.Success:

                        lblID.Text = _client.ClientID.ToString();

                        DataBack?.Invoke(this, _client.ClientID);

                        MessageBox.Show("Client saved successfully.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();

                        break;

                    case enOperationResult.NoPermission:

                        MessageBox.Show("You do not have permission to save this client.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;

                    case enOperationResult.AlreadyExists:

                        MessageBox.Show("A client with this National No already exists.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;

                    case enOperationResult.Failed:

                        MessageBox.Show("The client could not be saved.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void _GoToNextTab()
        {
            if (tpInfo.SelectedIndex < tpInfo.TabCount - 1)
            {
                tpInfo.SelectedIndex++;

                btnPrevious.Enabled = true;

                if (tpInfo.SelectedIndex == tpInfo.TabCount - 1)
                {
                    btnNextSave.TextButton = _clientID == -1  ? "Save": "Update";
                }

                return;
            }

            _SaveClient();
        }

        private void _GoToPreviousTab()
        {
            if (tpInfo.SelectedIndex > 0)
            {
                tpInfo.SelectedIndex--;


                if (tpInfo.SelectedIndex == 0)
                    btnPrevious.Enabled = false;


                btnNextSave.TextButton =
                    "Next  →";
            }
        }

        private async void frmAddNewEmployeeClient_Load(object sender, EventArgs e)
        {
            await _LoadForm();
        }

        private void btnNextSave_Click(object sender, EventArgs e)
        {
            _GoToNextTab();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tpInfo.TabIndex != 0)
                btnNextSave.TextButton = "Next  →";

            _GoToPreviousTab();
        }

        private void rbMale_Click_1(object sender, EventArgs e)
        {
            if (_clientID == -1)
                pbImage.Image = Resources.Male_Employee1;

            else
            {
                if (string.IsNullOrEmpty(_client.PersonInfo.ImagePath))
                    pbImage.Image = Resources.Male_Employee1;
            }

            rbFemale.Checked = false;
        }

        private void rbFemale_Click_1(object sender, EventArgs e)
        {
            if (_clientID == -1)
                pbImage.Image = Resources.Female_Employee;

            else
            {
                if (string.IsNullOrEmpty(_client.PersonInfo.ImagePath))
                    pbImage.Image = Resources.Female_Employee;
            }

            rbMale.Checked = false;
        }

        private void llSetImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openFileDialog1.FileName;

                llRemoveImage.Enabled = true;
            }
        }

        private void llRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_Employee1;
            else
                pbImage.Image = Resources.Female_Employee;

            llRemoveImage.Enabled = false;
        }
    }
}
using AtlantisBank.BLL;
using System.Windows.Forms;

namespace Atlantis_Bank.Main
{
    public partial class ctrlPersonalContactInfo : UserControl
    {
        public ctrlPersonalContactInfo()
        {
            InitializeComponent();
        }

        clsPerson _Person = new clsPerson();

        public void LoadData(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person != null)
            {
                lblFirstName.Text = _Person.FirstName;

                lblSecondName.Text = _Person.SecondName;

                lblLastName.Text = _Person.LastName;

                lblEmail.Text = _Person.Email;

                lblPhone.Text = _Person.Phone;

                lblNationalNo.Text = _Person.NationalNo;

                lblGender.Text = (_Person.Gender) ? "Female" : "Male";

                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();

                lblCountry.Text = _Person.CountryInfo.CountryName;

                lblAddress.Text = _Person.Address;

                pbImage.ImageLocation = _Person.ImagePath;
            }
        }
    }
}

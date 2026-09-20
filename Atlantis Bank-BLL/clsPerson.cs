using AtlantisBank.DAL;
using System;

namespace AtlantisBank.BLL
{
    public class clsPerson
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        public enMode Mode { get; private set; }

        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string NationalNo { get; set; }

        public bool Gender { get; set; }

        public clsCountry CountryInfo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ImagePath { get; set; }


        public clsPerson()
        {
            Mode = enMode.AddNew;

            PersonID = -1;

            FirstName = "";
            SecondName = "";
            LastName = "";
            NationalNo = "";

            Gender = false;

            CountryInfo = new clsCountry();

            DateOfBirth = DateTime.Now.AddYears(-18);

            Address = "";
            Email = "";
            Phone = "";
            ImagePath = "";
        }


        public clsPerson(
            int PersonID,
            string FirstName,
            string SecondName,
            string LastName,
            string NationalNo,
            bool Gender,
            int CountryID,
            DateTime DateOfBirth,
            string Address,
            string Email,
            string Phone,
            string ImagePath)
        {
            Mode = enMode.Update;

            this.PersonID = PersonID;

            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.Gender = Gender;

            this.CountryInfo = clsCountry.Find(CountryID);

            this.DateOfBirth = DateOfBirth;

            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.ImagePath = ImagePath;
        }


        private bool _AddNewPerson()
        {
            PersonID = clsPersonData.AddNewPerson(
                FirstName,
                SecondName,
                LastName,
                NationalNo,
                Gender,
                CountryInfo.CountryID,
                DateOfBirth,
                Address,
                Email,
                Phone,
                ImagePath);

            return PersonID != -1;
        }


        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(
                PersonID,
                FirstName,
                SecondName,
                LastName,
                NationalNo,
                Gender,
                CountryInfo.CountryID,
                DateOfBirth,
                Address,
                Email,
                Phone,
                ImagePath);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;

                        return true;
                    }

                    return false;


                case enMode.Update:

                    return _UpdatePerson();
            }

            return false;
        }


        public static clsPerson Find(int PersonID)
        {
            string FirstName = "";
            string SecondName = "";
            string LastName = "";
            string NationalNo = "";

            bool Gender = false;

            int CountryID = -1;

            DateTime DateOfBirth = DateTime.Now;

            string Address = "";
            string Email = "";
            string Phone = "";
            string ImagePath = "";

            bool IsFound = clsPersonData.GetPersonByID(
                PersonID,
                ref FirstName,
                ref SecondName,
                ref LastName,
                ref NationalNo,
                ref Gender,
                ref CountryID,
                ref DateOfBirth,
                ref Address,
                ref Email,
                ref Phone,
                ref ImagePath);

            if (!IsFound)
                return null;

            return new clsPerson(
                PersonID,
                FirstName,
                SecondName,
                LastName,
                NationalNo,
                Gender,
                CountryID,
                DateOfBirth,
                Address,
                Email,
                Phone,
                ImagePath);
        }


        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;

            string FirstName = "";
            string SecondName = "";
            string LastName = "";

            bool Gender = false;

            int CountryID = -1;

            DateTime DateOfBirth = DateTime.Now;

            string Address = "";
            string Email = "";
            string Phone = "";
            string ImagePath = "";

            bool IsFound = clsPersonData.GetPersonByNationalNo(
                NationalNo,
                ref PersonID,
                ref FirstName,
                ref SecondName,
                ref LastName,
                ref Gender,
                ref CountryID,
                ref DateOfBirth,
                ref Address,
                ref Email,
                ref Phone,
                ref ImagePath);

            if (!IsFound)
                return null;

            return new clsPerson(
                PersonID,
                FirstName,
                SecondName,
                LastName,
                NationalNo,
                Gender,
                CountryID,
                DateOfBirth,
                Address,
                Email,
                Phone,
                ImagePath);
        }


        public static bool IsPersonExists(int PersonID)
        {
            return clsPersonData.IsPersonExists(PersonID);
        }
    }
}
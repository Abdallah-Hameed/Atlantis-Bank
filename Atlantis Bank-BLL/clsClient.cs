using Atlantis_Bank_DAL;
using AtlantisBank.BLL;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Atlantis_Bank_BLL
{
    public class clsClient
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode { get; set; }

        public int ClientID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public clsBranch BranchInfo { get; set; }

        public DateTime RegDate { get; set; }

        public bool IsActive { get; set; }


        public clsClient()
        {
            this.ClientID = -1;

            this.PersonInfo = new clsPerson();

            this.RegDate = DateTime.Now;

            this.BranchInfo = new clsBranch();

            this.IsActive = true;

            Mode = enMode.AddNew;
        }


        private clsClient(int ClientID, clsPerson PersonInfo, DateTime RegDate, int BranchID, bool IsActive)
        {
            this.ClientID = ClientID;

            this.PersonInfo = PersonInfo;

            this.BranchInfo = clsBranch.Find(BranchID);

            this.RegDate = RegDate;

            this.IsActive = IsActive;

            Mode = enMode.Update;
        }


        private bool _AddNewClient()
        {
            this.ClientID = clsClientData.AddNewClient(this.PersonInfo.FirstName, this.PersonInfo.SecondName, this.PersonInfo.LastName,
                this.PersonInfo.NationalNo, this.PersonInfo.Gender, this.PersonInfo.CountryInfo.CountryID, this.PersonInfo.DateOfBirth, 
                this.PersonInfo.Address, this.PersonInfo.Email, this.PersonInfo.Phone, this.PersonInfo.ImagePath, this.RegDate, this.BranchInfo.BranchID);

            return this.ClientID != -1;
        }


        private bool _UpdateClient()
        {
            bool result = clsClientData.UpdateClient(this.ClientID, this.PersonInfo.FirstName, this.PersonInfo.SecondName, this.PersonInfo.LastName, 
                this.PersonInfo.NationalNo, this.PersonInfo.Gender, this.PersonInfo.CountryInfo.CountryID, this.PersonInfo.DateOfBirth, 
                this.PersonInfo.Address, this.PersonInfo.Email, this.PersonInfo.Phone, this.PersonInfo.ImagePath, this.RegDate,
                this.BranchInfo.BranchID, this.IsActive);

            return result;
        }


        public static clsClient Find(int ClientID)
        {
            int PersonID = -1;

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

            DateTime RegDate = DateTime.Now;

            int BranchID = -1;

            bool IsActive = false;


            bool isFound = clsClientData.GetClientByID(ClientID, ref PersonID, ref FirstName, ref SecondName, ref LastName, ref NationalNo, 
                ref Gender, ref CountryID, ref DateOfBirth, ref Address, ref Email, ref Phone, ref ImagePath, ref RegDate, ref BranchID, ref IsActive);


            if (isFound)
            {
                clsPerson PersonInfo = new clsPerson(PersonID, FirstName, SecondName, LastName, NationalNo, Gender, CountryID, DateOfBirth, Address, Email, Phone, ImagePath);

                return new clsClient(ClientID, PersonInfo, RegDate, BranchID, IsActive);
            }

            return null;
        }


        public static clsClient Find(string NationalNo)
        {
            int ClientID = -1;

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

            DateTime RegDate = DateTime.Now;

            int BranchID = -1;

            bool IsActive = false;


            bool isFound = clsClientData.GetClientByNationalNo(NationalNo, ref ClientID, ref PersonID, ref FirstName, ref SecondName, ref LastName,
                ref Gender, ref CountryID, ref DateOfBirth, ref Address, ref Email, ref Phone, ref ImagePath, ref RegDate, ref BranchID, ref IsActive);


            if (isFound)
            {
                clsPerson PersonInfo = new clsPerson(PersonID, FirstName, SecondName, LastName, NationalNo, Gender, CountryID, DateOfBirth, Address, Email, Phone, ImagePath);

                return new clsClient(ClientID, PersonInfo, RegDate, BranchID, IsActive);
            }

            return null;
        }


        public enOperationResult Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (!clsAuthorization.HasPermission("Client_Add"))
                        return enOperationResult.NoPermission;

                    // Prevent duplicate Client for the same NationalNo.
                    if (Find(this.PersonInfo.NationalNo) != null)
                        return enOperationResult.AlreadyExists;

                    if (_AddNewClient())
                    {
                        Mode = enMode.Update;

                        return enOperationResult.Success;
                    }

                    return enOperationResult.Failed;


                case enMode.Update:

                    if (!clsAuthorization.HasPermission("Client_Edit"))
                        return enOperationResult.NoPermission;

                    if (_UpdateClient())
                        return enOperationResult.Success;

                    return enOperationResult.Failed;
            }

            return enOperationResult.InvalidOperation;
        }


        public static async Task<DataTable> GetAllClientsAsync()
        {
            if (!clsAuthorization.HasPermission("Client_View"))
                return new DataTable();

            return await clsClientData.GetAllClientsAsync();
        }


        public static enOperationResult DeleteClient(int ClientID)
        {
            if (!clsAuthorization.HasPermission("Client_Delete"))
                return enOperationResult.NoPermission;

            if (!clsClientData.IsClientExists(ClientID))
                return enOperationResult.NotFound;

            if (clsClientData.DeleteClient(ClientID))
                return enOperationResult.Success;

            return enOperationResult.Failed;
        }


        public static bool IsClientExists(int ClientID)
        {
            return clsClientData.IsClientExists(ClientID);
        }


        public static bool IsClientActive(int ClientID)
        {
            return clsClientData.IsClientActive(ClientID);
        }
    }
}
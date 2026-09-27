using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.DTOs.Client;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Atlantis_Bank_API.Mappers
{
    public class clsClientMapper
    {
        public static IEnumerable<clsClientDto> Map(DataTable dt)
        {
            List<clsClientDto> clients = new List<clsClientDto>();

            foreach (DataRow row in dt.Rows)
            {
                clients.Add(new clsClientDto
                {
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    NationalNo = row["NationalNo"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    SecondName = row["SecondName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                    Age = Convert.ToInt32(row["Age"]),
                    CountryName = row["CountryName"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    BranchName = row["BranchName"].ToString(),
                    GenderText = row["GenderText"].ToString()
                });
            }

            return clients;
        }

        public static clsClientDto Map(clsClient client)
        {
            return new clsClientDto
            {
                ClientID = client.ClientID,
                NationalNo = client.PersonInfo.NationalNo,
                FirstName = client.PersonInfo.FirstName,
                SecondName = client.PersonInfo.SecondName,
                LastName = client.PersonInfo.LastName,
                DateOfBirth = client.PersonInfo.DateOfBirth,
                Age = CalculateAge(client.PersonInfo.DateOfBirth),
                CountryName = client.PersonInfo.CountryInfo.CountryName,
                Phone = client.PersonInfo.Phone,
                Email = client.PersonInfo.Email,
                BranchName = client.BranchInfo.BranchName,
                GenderText = client.PersonInfo.Gender ? "Male" : "Female"
            };
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
                age--;

            return age;
        }

        public static void MapToClient(clsAddClientDto dto, clsClient client)
        {
            client.PersonInfo.FirstName = dto.FirstName;
            client.PersonInfo.SecondName = dto.SecondName;
            client.PersonInfo.LastName = dto.LastName;
            client.PersonInfo.NationalNo = dto.NationalNo;
            client.PersonInfo.Gender = dto.Gender;
            client.PersonInfo.CountryInfo = clsCountry.Find(dto.CountryID);
            client.PersonInfo.DateOfBirth = dto.DateOfBirth;
            client.PersonInfo.Address = dto.Address;
            client.PersonInfo.Email = dto.Email;
            client.PersonInfo.Phone = dto.Phone;
            client.PersonInfo.ImagePath = dto.ImagePath;
            client.BranchInfo = clsBranch.Find(dto.BranchID);
        }
    }
}
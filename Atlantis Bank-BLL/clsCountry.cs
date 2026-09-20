using AtlantisBank.DAL;
using System.Data;
using System.Threading.Tasks;

namespace AtlantisBank.BLL
{
    public class clsCountry
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public clsCountry()
        {
            CountryID = -1;

            CountryName = "";
        }

        public clsCountry(int CountryID,string CountryName)
        {
            this.CountryID = CountryID;

            this.CountryName = CountryName;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            bool isFound = clsCountryData.GetCountryByID(CountryID, ref CountryName);

            if(isFound)
            {
                return new clsCountry(CountryID, CountryName);
            }

            return null;
        }

        public static async Task <DataTable> GetAllCountries()
        {
            return await clsCountryData.GetAllCountries();
        }
    }
}
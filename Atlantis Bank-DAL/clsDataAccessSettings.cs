using System.Configuration;

namespace Atlantis_Bank_DAL
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString =
            ConfigurationManager.ConnectionStrings["AtlantisBankDB"].ConnectionString;
    }
}
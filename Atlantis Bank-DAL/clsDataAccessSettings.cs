using System.Configuration;

namespace Atlantis_Bank_DAL
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString { get; set; }
            = "Server=.;Database=AtlantisBankDB;Integrated Security=true;TrustServerCertificate=true";
    }
}
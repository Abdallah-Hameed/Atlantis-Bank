namespace Atlantis_Bank_API.DTOs.User
{
    public class clsUserListDto
    {
        public int UserID { get; set; }

        public int EmployeeID { get; set; }

        public string UserName { get; set; }

        public string Branch { get; set; }

        public string Position { get; set; }

        public string Role { get; set; }
    }
}
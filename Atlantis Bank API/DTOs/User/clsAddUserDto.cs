namespace Atlantis_Bank_API.DTOs.User
{
    public class clsAddUserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public int RoleID { get; set; }

        public int EmployeeID { get; set; }
    }
}
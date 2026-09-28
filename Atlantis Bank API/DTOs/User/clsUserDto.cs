namespace Atlantis_Bank_API.DTOs.User
{
    public class clsUserDto
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public bool Active { get; set; }

        public int RoleID { get; set; }

        public int EmployeeID { get; set; }
    }
}
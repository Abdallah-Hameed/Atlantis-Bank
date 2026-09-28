namespace Atlantis_Bank_API.Authorization
{
    public class clsUserUpdateResource
    {
        public int TargetUserId { get; set; }
        public int TargetCurrentRoleId { get; set; }
        public int NewRoleId { get; set; }
    }
}
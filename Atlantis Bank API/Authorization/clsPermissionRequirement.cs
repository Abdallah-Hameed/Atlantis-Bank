using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Authorization
{
    public class clsPermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }

        public clsPermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
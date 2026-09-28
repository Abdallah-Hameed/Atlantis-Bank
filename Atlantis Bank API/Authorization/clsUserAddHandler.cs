using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;

namespace Atlantis_Bank_API.Authorization
{
    public class clsUserAddHandler : AuthorizationHandler<OperationAuthorizationRequirement, clsUserAddResource>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            clsUserAddResource resource)
        {
            if (requirement.Name != "User_Add")
                return Task.CompletedTask;

            var roleIdClaim = context.User.FindFirst("RoleID")?.Value;
            if (!int.TryParse(roleIdClaim, out int currentRoleId))
                return Task.CompletedTask;

            bool isSuperAdmin = (currentRoleId == 3);

            if (!isSuperAdmin && resource.NewRoleId >= currentRoleId)
                return Task.CompletedTask;

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
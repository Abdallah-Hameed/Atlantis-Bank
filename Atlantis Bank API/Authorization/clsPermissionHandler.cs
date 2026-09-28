using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Authorization
{
    public class clsPermissionHandler : AuthorizationHandler<clsPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            clsPermissionRequirement requirement)
        {
            if (context.User.HasClaim("Permission", requirement.Permission))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
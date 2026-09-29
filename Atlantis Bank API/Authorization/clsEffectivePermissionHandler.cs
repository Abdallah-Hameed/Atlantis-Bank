using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Authorization
{
    public class clsEffectivePermissionHandler : AuthorizationHandler<clsPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            clsPermissionRequirement requirement)
        {
            if (context.User.HasClaim("Permission", requirement.Permission))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (context.User.HasClaim("PositionPermission", requirement.Permission))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
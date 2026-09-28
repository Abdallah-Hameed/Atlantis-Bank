using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;

namespace Atlantis_Bank_API.Authorization
{
    public class clsUserUpdateHandler : AuthorizationHandler<OperationAuthorizationRequirement, clsUserUpdateResource>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            clsUserUpdateResource resource)
        {
            if (requirement.Name != "User_Update")
                return Task.CompletedTask;

            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int currentUserId))
                return Task.CompletedTask;

            var roleIdClaim = context.User.FindFirst("RoleID")?.Value;
            if (!int.TryParse(roleIdClaim, out int currentRoleId))
                return Task.CompletedTask;

            bool isSelf = (currentUserId == resource.TargetUserId);

            if (isSelf)
            {
                if (resource.NewRoleId > currentRoleId)
                    return Task.CompletedTask;

                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            bool hasEditPermission = context.User.HasClaim("Permission", "User_Edit");

            if (!hasEditPermission)
                return Task.CompletedTask;

            if (resource.TargetCurrentRoleId >= currentRoleId)
                return Task.CompletedTask;

            if (resource.NewRoleId >= currentRoleId)
                return Task.CompletedTask;

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
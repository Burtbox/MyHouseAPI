using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Authorization.Policies;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MyHouseAPI.Repositories;

namespace MyHouseAPI.Authorization.Handlers
{
    public class OwnUserIdHandler : AuthorizationHandler<OwnUserIdRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OwnUserIdRequirement requirement
        )
        {
            if (!context.User.HasClaim(c =>
                c.Type == "user_id" &&
                c.Issuer == "https://securetoken.google.com/myhouse-a01c7" //TODO move this into config
            ))
            {
                return Task.CompletedTask;
            }

            string userId =
                context.User.FindFirst(c =>
                    c.Type == "user_id" &&
                    c.Issuer == "https://securetoken.google.com/myhouse-a01c7"
                ).Value;

            if (userId == requirement.UserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

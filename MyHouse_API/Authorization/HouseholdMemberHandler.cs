using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Authorization.Policies;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MyHouseAPI.Repositories;
using Microsoft.Extensions.Options;
using MyHouseAPI.Model;

namespace MyHouseAPI.Authorization.Handlers
{
    public class OwnUserIdHandler : AuthorizationHandler<OwnUserIdRequirement, string>
    {
        private readonly IOptions<AppSettings> appSettings;
        public OwnUserIdHandler(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OwnUserIdRequirement requirement,
            string userId
        )
        {
            if (!context.User.HasClaim(c =>
                c.Type == "user_id" &&
                c.Issuer == appSettings.Value.Firebase.Issuer
            ))
            {
                return Task.CompletedTask;
            }

            string claimsUserId =
                context.User.FindFirst(c =>
                    c.Type == "user_id" &&
                    c.Issuer == appSettings.Value.Firebase.Issuer
                ).Value;

            if (claimsUserId == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

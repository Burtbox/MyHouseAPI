using MyHouseAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MyHouseAPI.Authorization.Handlers;
using MyHouseAPI.Authorization.Policies;
using Microsoft.AspNetCore.Authorization;

namespace MyHouseAPI.Services
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(configuration =>
            {
                configuration.AddPolicy("isUser", policy =>
                {
                    policy.RequireRole("User");
                });
                configuration.AddPolicy("HouseholdMember", policy =>
                {
                    //TODO don't hardcode this ED!
                    policy.Requirements.Add(new HouseholdMemberRequirement(1));
                });
            });
            services.AddScoped<IAuthorizationHandler, HouseholdMemberHandler>();

            return services;
        }
    }
}

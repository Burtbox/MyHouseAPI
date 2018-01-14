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
                configuration.AddPolicy("OwnUserId", policy =>
                {
                    //TODO don't hardcode this ED!
                    policy.Requirements.Add(new OwnUserIdRequirement("70ajxWmrS6XIU53GL6bj1VcjCsm1"));
                });
            });
            services.AddScoped<IAuthorizationHandler, OwnUserIdHandler>();

            return services;
        }
    }
}

using MyHouseAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

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
            });

            return services;
        }
    }
}

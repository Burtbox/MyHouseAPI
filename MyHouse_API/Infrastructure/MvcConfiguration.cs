
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.AspNetCore;

namespace MyHouseAPI.Services
{
    public static class MvcConfiguration
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddMvc(configuration =>
            {
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configuration.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddFluentValidation();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.AspNetCore;
using MyHouseAPI.FilterAttributes;
using Newtonsoft.Json;

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
                configuration.Filters.Add(typeof(ModelStateValidationActionFilterAttribute));
            })
            .AddFluentValidation()
            .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });

            return services;
        }
    }
}

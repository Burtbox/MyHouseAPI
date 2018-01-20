using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyHouseAPI.Handlers;
using Microsoft.AspNetCore.Http;

namespace MyHouseAPI.Services
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped((IServiceProvider scoped) =>
                new ConnectionHandler(configuration.GetConnectionString(name: "DefaultConnection"))
            );

            return services;
        }
    }
}

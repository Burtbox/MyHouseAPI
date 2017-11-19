using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HouseMoneyAPI.Helpers;
using Microsoft.AspNetCore.Http;

namespace HouseMoneyAPI.Services
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped((IServiceProvider scoped) =>
                new ConnectionHelper(configuration.GetConnectionString(name: "DefaultConnection"))
            );

            return services;
        }
    }
}

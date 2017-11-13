using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace HouseMoneyAPI.Services {
    public static class SerilogConfiguration
    {
        public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            LoggerConfiguration logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext();

            services.AddSingleton<ILogger>(logger.CreateLogger());

            return services;
        }
    }
}

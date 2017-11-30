using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MyHouseAPI.Services {
    public static class SerilogConfiguration
    {
        public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            LoggerConfiguration logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext();
            ILogger log = logger.CreateLogger();
            services.AddSingleton<ILogger>(log);
            log.Information("Logging initialised");

            return services;
        }
    }
}

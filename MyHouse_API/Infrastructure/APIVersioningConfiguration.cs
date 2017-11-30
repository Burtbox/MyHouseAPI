
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace MyHouseAPI.Services {
    public static class APIVersioningConfiguration
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(version => {
                version.DefaultApiVersion = new ApiVersion(3, 0);
                version.AssumeDefaultVersionWhenUnspecified = true;
                version.ReportApiVersions = true;
            });

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace MyHouseAPI.Services
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders", builder =>
                {
                    builder.AllowAnyOrigin() //TODO: Limit cors
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}

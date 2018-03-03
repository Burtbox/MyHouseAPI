using Microsoft.Extensions.DependencyInjection;

namespace MyHouseAPI.Services
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowExpectedRequests", builder =>
                {
                    string[] allowedHeaders = new string[]
                    {
                        "Accept",
                        "Accept-Encoding",
                        "Accept-Language",
                        "Access-Control-Request-Headers",
                        "Access-Control-Request-Method",
                        "Connection",
                        "Host",
                        "Origin",
                        "Referer",
                        "User-Agent",
                    };
                    string[] allowedMethods = new string[] { "GET", "POST", "PUT", "DELETE" };
                    string[] allowedOrigins = new string[]
                    {
                        "http://localhost:3000/",
                        "http://myhouse.surge.sh/",
                        "http://housemoney.surge.sh/",
                        "http://housefood.surge.sh/",
                    };
                    builder
                        .WithHeaders(allowedHeaders)
                        .WithMethods(allowedMethods)
                        .WithOrigins(allowedOrigins);
                });
            });

            return services;
        }
    }
}

using System.Text;
using HouseMoneyAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HouseMoneyAPI.Services
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(authentication => {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(cfg => cfg.SlidingExpiration = true)
            .AddJwtBearer(jwtConfiguration =>
            {
                jwtConfiguration.Authority = "https://securetoken.google.com/myhouse-a01c7";
                jwtConfiguration.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/myhouse-a01c7",
                    ValidateAudience = true,
                    ValidAudience = "myhouse-a01c7",
                    ValidateLifetime = true
                };

            });

            return services;
        }
    }
}

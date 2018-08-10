using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyHouseAPI.Model;

namespace MyHouseAPI.Services
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string firebaseIssuer = configuration.GetSection("AppSettings:Firebase:Issuer").Value;
            string firebaseAudience = configuration.GetSection("AppSettings:Firebase:Audience").Value;
            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(cfg => cfg.SlidingExpiration = true)
            .AddJwtBearer(jwtConfiguration =>
            {
                jwtConfiguration.Authority = firebaseIssuer;
                jwtConfiguration.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = firebaseIssuer,
                    ValidateAudience = true,
                    ValidAudience = firebaseAudience,
                    ValidateLifetime = true
                };

            });

            return services;
        }
    }
}

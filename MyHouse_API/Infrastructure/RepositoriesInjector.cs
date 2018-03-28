using MyHouseAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MyHouseAPI.Repositories.Houses;
using MyHouseAPI.Repositories.Authorization;
using MyHouseAPI.Repositories.Money;

namespace MyHouseAPI.Services
{
    public static class RepositoriesInjector
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
             .AddScoped<OccupantsRepository>()
             .AddScoped<HouseholdsRepository>()
             .AddScoped<NewsFeedsRepository>()
             .AddScoped<BalanceRepository>()
             .AddScoped<AuthorizationRepository>();

            return services;
        }
    }
}

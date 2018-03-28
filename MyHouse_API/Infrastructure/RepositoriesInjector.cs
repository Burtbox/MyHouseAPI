using MyHouseAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MyHouseAPI.Repositories.Houses;
using MyHouseAPI.Repositories.Authorization;

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
             .AddScoped<AuthorizationRepository>();

            return services;
        }
    }
}

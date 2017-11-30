using MyHouseAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MyHouseAPI.Services {
    public static class RepositoriesInjector
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<OccupantsRepository>();
            services.AddScoped<HouseholdsRepository>();

            return services;
        }
    }
}

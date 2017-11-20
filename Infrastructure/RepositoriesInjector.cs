using HouseMoneyAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HouseMoneyAPI.Services {
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

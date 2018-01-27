using FluentValidation;
using MyHouseAPI.Model;
using MyHouseAPI.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace MyHouseAPI.Services
{
    public static class ValidatoinInjector
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Household>, HouseholdsValidator>();
            services.AddTransient<IValidator<Occupant>, OccupantsValidator>();

            return services;
        }
    }
}

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
            services.AddTransient<IValidator<HouseholdResponse>, HouseholdsValidator>();
            services.AddTransient<IValidator<OccupantResponse>, OccupantsValidator>();

            return services;
        }
    }
}

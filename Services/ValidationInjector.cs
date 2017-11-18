using FluentValidation;
using HouseMoneyAPI.Model;
using HouseMoneyAPI.Repositories;
using HouseMoneyAPI.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace HouseMoneyAPI.Services {
    public static class ValidatoinInjector
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Occupant>, OccupantsValidator>();
            services.AddTransient<IValidator<OccupantInsert>, OccupantsInsertValidator>();
            services.AddTransient<IValidator<Household>, HouseholdsValidator>();

            return services;
        }
    }
}

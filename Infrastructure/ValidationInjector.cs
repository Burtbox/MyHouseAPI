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
            services.AddTransient<IValidator<Household>, HouseholdsValidator>();
            services.AddTransient<IValidator<Occupant>, OccupantsValidator>();
            services.AddTransient<IValidator<OccupantInsert>, OccupantsInsertValidator>();

            return services;
        }
    }
}

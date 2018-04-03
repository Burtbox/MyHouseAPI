using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyHouseAPI.Model.Houses;
using MyHouseAPI.Model.Money;
using MyHouseAPI.Validation.Houses;
using MyHouseAPI.Validation.Money;

namespace MyHouseAPI.Services
{
    public static class ValidatoinInjector
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            return services
             .AddTransient<IValidator<HouseholdInsertRequest>, HouseholdInsertRequestValidator>()
             .AddTransient<IValidator<HouseholdUpdateRequest>, HouseholdUpdateRequestValidator>()
             .AddTransient<IValidator<OccupantInsertRequest>, OccupantInsertRequestValidator>()
             .AddTransient<IValidator<OccupantUpdateRequest>, OccupantUpdateRequestValidator>()
             .AddTransient<IValidator<NewsFeedInsertRequest>, NewsFeedInsertRequestValidator>()
             .AddTransient<IValidator<TransactionInsertRequest>, TransactionInsertRequestValidator>();
        }
    }
}

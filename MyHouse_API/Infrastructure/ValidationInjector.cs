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
            return services
             .AddTransient<IValidator<HouseholdInsertRequest>, HouseholdInsertRequestValidator>()
             .AddTransient<IValidator<HouseholdUpdateRequest>, HouseholdUpdateRequestValidator>()
             .AddTransient<IValidator<OccupantInsertRequest>, OccupantInsertRequestValidator>()
             .AddTransient<IValidator<OccupantUpdateRequest>, OccupantUpdateRequestValidator>()
             .AddTransient<IValidator<NewsFeedInsertRequest>, NewsFeedInsertRequestValidator>();
        }
    }
}

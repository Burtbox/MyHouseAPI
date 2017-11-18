using FluentValidation;
using HouseMoneyAPI.Model;

namespace HouseMoneyAPI.Validation
{
    public class HouseholdsValidator: AbstractValidator<Household>
    {
        public HouseholdsValidator() {
            RuleFor(x => x.HouseholdId).NotNull();
            RuleFor(x => x.HouseholdId).GreaterThan(0);
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).MaximumLength(100);
        }
    }
}

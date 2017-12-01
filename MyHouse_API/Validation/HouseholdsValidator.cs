using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public class HouseholdsValidator: AbstractValidator<Household>
    {
        public HouseholdsValidator() {
            RuleFor(x => x.HouseholdId).NotEmpty();
            RuleFor(x => x.HouseholdId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(100);
        }
    }
}

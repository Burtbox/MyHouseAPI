using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public class HouseholdsValidator : AbstractValidator<HouseholdResponse>
    {
        public HouseholdsValidator()
        {
            RuleFor(x => x.HouseholdId)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}

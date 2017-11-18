using FluentValidation;
using HouseMoneyAPI.Model;

namespace HouseMoneyAPI.Validation
{
    public class OccupantsInsertValidator: AbstractValidator<OccupantInsert>
    {
        public OccupantsInsertValidator() {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).MaximumLength(36);
            RuleFor(x => x.DisplayName).NotNull();
            RuleFor(x => x.DisplayName).MaximumLength(100);
            RuleFor(x => x.HouseholdId).NotNull();
            RuleFor(x => x.HouseholdId).GreaterThan(0);
        }
    }
}

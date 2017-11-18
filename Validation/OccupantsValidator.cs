using FluentValidation;
using HouseMoneyAPI.Model;

namespace HouseMoneyAPI.Validation
{
    public class OccupantsValidator: AbstractValidator<Occupant>
    {
        public OccupantsValidator() {
            RuleFor(x => x.OccupantId).NotNull();
            RuleFor(x => x.OccupantId).GreaterThan(0);
            //ED! These should come from the insert validator - need to think about how these should work 
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).MaximumLength(36);
            RuleFor(x => x.DisplayName).NotNull();
            RuleFor(x => x.DisplayName).MaximumLength(100);
            RuleFor(x => x.HouseholdId).NotNull();
            RuleFor(x => x.HouseholdId).GreaterThan(0);
        }
    }
}

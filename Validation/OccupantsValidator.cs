using FluentValidation;
using HouseMoneyAPI.Model;

namespace HouseMoneyAPI.Validation
{
    public class OccupantsValidator: AbstractValidator<Occupant>
    {
        public OccupantsValidator() {
            RuleFor(x => x.OccupantId).NotNull();
            RuleFor(x => x.HouseholdId).NotNull();
        }
    }
}

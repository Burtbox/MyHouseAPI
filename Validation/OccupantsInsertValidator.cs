using FluentValidation;
using HouseMoneyAPI.Model;

namespace HouseMoneyAPI.Validation
{
    public class OccupantsInsertValidator: AbstractValidator<OccupantInsert>
    {
        public OccupantsInsertValidator() {
            RuleFor(x => x.HouseholdId).NotNull();
            RuleFor(x => x.UserId).NotNull();
        }
    }
}

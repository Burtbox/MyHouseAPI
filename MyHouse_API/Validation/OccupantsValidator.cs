using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public class OccupantsValidator : OccupantsValidatorBase
    {

    }
    public class OccupantsInsertValidator : OccupantsValidatorBase
    {
        public OccupantsInsertValidator()
        {
            RuleFor(x => x.OccupantId).NotEmpty();
            RuleFor(x => x.OccupantId).GreaterThan(0);
        }
    }

    public abstract class OccupantsValidatorBase : AbstractValidator<Occupant>
    {
        public OccupantsValidatorBase()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).Length(36);
            RuleFor(x => x.DisplayName).NotEmpty();
            RuleFor(x => x.DisplayName).MaximumLength(100);
            RuleFor(x => x.HouseholdId).NotEmpty();
            RuleFor(x => x.HouseholdId).GreaterThan(0);
        }
    }
}

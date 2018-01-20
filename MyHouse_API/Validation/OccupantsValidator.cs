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
            RuleFor(x => x.OccupantId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public abstract class OccupantsValidatorBase : AbstractValidator<Occupant>
    {
        public OccupantsValidatorBase()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .Length(36);

            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .MaximumLength(100);
                
            RuleFor(x => x.HouseholdId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}

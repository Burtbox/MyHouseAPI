using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public abstract class OccupantsDetailsValidator : AbstractValidator<OccupantDetails>
    {
        public OccupantsDetailsValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MinimumLength(28) //Firebase userIds are currently 28 but may increase to 36
                .MaximumLength(36);

            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.HouseholdId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class OccupantsValidator : AbstractValidator<Occupant> //TODO: Ed check that this inherits the userId, DisplayName and HouseholdId!
    {
        public OccupantsValidator()
        {
            RuleFor(x => x.OccupantId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class OccupantsInsertValidator : AbstractValidator<OccupantInsert>
    {
        public OccupantsInsertValidator()
        {
            RuleFor(x => x.EnteredBy)
            .NotEmpty()
            .MinimumLength(28)
            .MaximumLength(36); //TODO - roll this into a custom "IsFirebaseUserId" function!
        }
    }

    public class OccupantsUpdateValidator : AbstractValidator<OccupantUpdate>
    {
        public OccupantsUpdateValidator()
        {
            RuleFor(x => x.ModifiedBy)
            .NotEmpty()
            .MinimumLength(28)
            .MaximumLength(36); //TODO - roll this into a custom "IsFirebaseUserId" function!
        }
    }
}

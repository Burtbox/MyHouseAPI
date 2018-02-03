using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public class HouseholdDetailsValidator : AbstractValidator<HouseholdDetails>
    {
        public HouseholdDetailsValidator()
        {
            // RuleFor(x => x.HouseholdId)
            //     .NotEmpty()
            //     .GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }

    public class HouseholdValidator : AbstractValidator<Household>
    {
        public HouseholdValidator()
        {
            RuleFor(x => x.HouseholdId)
                .NotEmpty()
                .GreaterThan(0);

        }
    }

    public class HouseholdInsertRequestValidator : AbstractValidator<HouseholdInsertRequest>
    {
        public HouseholdInsertRequestValidator()
        {
            RuleFor(x => x.EnteredBy).IsFirebaseUserId();
        }
    }

    public class HouseholdUpdateRequestValidator : AbstractValidator<HouseholdUpdateRequest>
    {
        public HouseholdUpdateRequestValidator()
        {
            RuleFor(x => x.ModifiedBy).IsFirebaseUserId();
        }
    }
}

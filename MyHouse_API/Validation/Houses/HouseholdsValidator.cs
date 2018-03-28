using FluentValidation;
using MyHouseAPI.Model.Houses;
using MyHouseAPI.Validation.Authorization;

namespace MyHouseAPI.Validation.Houses
{
    public class HouseholdDetailsValidator<T> : AbstractValidator<T> where T : HouseholdDetails
    {
        public HouseholdDetailsValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }

    public class HouseholdValidator<T> : HouseholdDetailsValidator<T> where T : Household
    {
        public HouseholdValidator()
        {
            RuleFor(x => x.OccupantId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class HouseholdInsertRequestValidator : HouseholdDetailsValidator<HouseholdInsertRequest>
    {
        public HouseholdInsertRequestValidator()
        {
            RuleFor(x => x.EnteredBy).IsFirebaseUserId();
            RuleFor(x => x.CreatorDisplayName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }

    public class HouseholdUpdateRequestValidator : HouseholdValidator<HouseholdUpdateRequest>
    {
        public HouseholdUpdateRequestValidator()
        {
            RuleFor(x => x.ModifiedBy).IsFirebaseUserId();
        }
    }
}

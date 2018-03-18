using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public abstract class OccupantsDetailsValidator<T> : AbstractValidator<T> where T : OccupantDetails
    {
        public OccupantsDetailsValidator()
        {
            RuleFor(x => x.UserId).IsFirebaseUserId();

            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }

    public class OccupantValidator<T> : OccupantsDetailsValidator<T> where T : Occupant
    {
        public OccupantValidator()
        {
            RuleFor(x => x.OccupantId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class OccupantInsertRequestValidator : OccupantValidator<OccupantInsertRequest>
    {
        public OccupantInsertRequestValidator()
        {
            RuleFor(x => x.EnteredBy).IsFirebaseUserId();
        }
    }

    public class OccupantUpdateRequestValidator : OccupantValidator<OccupantUpdateRequest> { }
}

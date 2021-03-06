using FluentValidation;
using MyHouseAPI.Model.Houses;
using MyHouseAPI.Validation.Authorization;

namespace MyHouseAPI.Validation.Houses
{
    public abstract class NewsFeedsDetailsValidator<T> : AbstractValidator<T> where T : NewsFeedDetails
    {
        public NewsFeedsDetailsValidator()
        {
            RuleFor(x => x.Headline)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.SubHeadline)
                .MaximumLength(200);

            RuleFor(x => x.Story)
                .NotEmpty();

            RuleFor(x => x.Author)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Recipient).IsFirebaseUserId();
        }
    }

    public class NewsFeedValidator<T> : NewsFeedsDetailsValidator<T> where T : NewsFeed
    {
        public NewsFeedValidator()
        {
            RuleFor(x => x.NewsFeedId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class NewsFeedInsertRequestValidator : NewsFeedsDetailsValidator<NewsFeedInsertRequest>
    {
        public NewsFeedInsertRequestValidator()
        {
            RuleFor(x => x.EnteredBy).IsFirebaseUserId();

            RuleFor(x => x.OccupantId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class NewsFeedUpdateRequestValidator : NewsFeedsDetailsValidator<NewsFeedUpdateRequest> { }
}

using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public abstract class NewsFeedsDetailsValidator<T> : AbstractValidator<T> where T : NewsFeedDetails
    {
        public NewsFeedsDetailsValidator()
        {
            RuleFor(x => x.OccupantId)
                .NotEmpty()
                .GreaterThan(0);

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
        }
    }

    public class NewsFeedUpdateRequestValidator : NewsFeedsDetailsValidator<NewsFeedUpdateRequest> { }
}

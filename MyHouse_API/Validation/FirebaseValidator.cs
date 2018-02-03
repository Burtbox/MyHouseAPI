using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public static class FirebaseValidator
    {
        public static IRuleBuilderOptions<T, string> IsFirebaseUserId<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
            .NotEmpty()
            .MinimumLength(28)
            .MaximumLength(36);
        }
    }
}

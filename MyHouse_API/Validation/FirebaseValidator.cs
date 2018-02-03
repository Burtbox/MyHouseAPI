using FluentValidation;
using MyHouseAPI.Model;

namespace MyHouseAPI.Validation
{
    public static class FirebaseValidator
    {
        public static IRuleBuilderOptions<T, string> IsFirebaseUserId<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(userId => string.IsNullOrEmpty(userId) == false).WithMessage("Invalid user id")
                .Must(userId => userId.Length > 28).WithMessage("Invalid user id")
                .Must(userId => userId.Length < 36).WithMessage("Invalid user id");
        }
    }
}

using FluentValidation;

namespace MyHouseAPI.Validation.Authorization
{
    public static class OccupantValidator
    {
        public static IRuleBuilderOptions<T, int> IsOccupantId<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
            .NotEmpty()
            .GreaterThan(0);
        }
    }
}

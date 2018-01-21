using Xunit;
using MyHouseAPI.Validation;
using FluentValidation.TestHelper;
using MyHouseUnitTests.Helpers;

namespace MyHouseUnitTests.ValidationTests
{
    public class HouseholdsValidatorTests
    {
        [Fact]
        public void Households_ShouldAllow()
        {
            HouseholdsValidator sut = new HouseholdsValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 9999);
            sut.ShouldNotHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(100));
        }

        [Fact]
        public void Households_ShouldValidate()
        {
            HouseholdsValidator sut = new HouseholdsValidator();
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, -1);
            sut.ShouldHaveValidationErrorFor(t => t.Name, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(101));
        }
    }
}

using Xunit;
using MyHouseAPI.Validation;
using FluentValidation.TestHelper;
using MyHouseUnitTests.Helpers;

namespace MyHouseUnitTests.ValidationTests
{
    public class HouseholdsValidatorTests
    {
        [Fact]
        public void HouseholdInsertRequest_ShouldAllow()
        {
            HouseholdInsertRequestValidator sut = new HouseholdInsertRequestValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(28));
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(36));

            sut.ShouldNotHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(100));
        }

        [Fact]
        public void HouseholdInsertRequest_ShouldValidate()
        {
            HouseholdInsertRequestValidator sut = new HouseholdInsertRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(37));

            sut.ShouldHaveValidationErrorFor(t => t.Name, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(101));
        }

        [Fact]
        public void HouseholdUpdateRequest_ShouldAllow()
        {
            HouseholdUpdateRequestValidator sut = new HouseholdUpdateRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(37));

            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 9999);
            sut.ShouldNotHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(100));
        }

        [Fact]
        public void HouseholdUpdateRequest_ShouldValidate()
        {
            HouseholdUpdateRequestValidator sut = new HouseholdUpdateRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(37));

            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, -1);
            sut.ShouldHaveValidationErrorFor(t => t.Name, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(101));
        }
    }
}

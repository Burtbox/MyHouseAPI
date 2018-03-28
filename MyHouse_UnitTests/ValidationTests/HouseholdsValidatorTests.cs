using Xunit;
using MyHouseAPI.Validation;
using FluentValidation.TestHelper;
using MyHouseUnitTests.Helpers;
using MyHouseAPI.Validation.Houses;

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
            sut.ShouldNotHaveValidationErrorFor(t => t.CreatorDisplayName, StringGenerator.RandomString(100));

            sut.ShouldNotHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(50));
        }

        [Fact]
        public void HouseholdInsertRequest_ShouldValidate()
        {
            HouseholdInsertRequestValidator sut = new HouseholdInsertRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(37));
            sut.ShouldHaveValidationErrorFor(t => t.CreatorDisplayName, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.CreatorDisplayName, "");
            sut.ShouldHaveValidationErrorFor(t => t.CreatorDisplayName, StringGenerator.RandomString(101));

            sut.ShouldHaveValidationErrorFor(t => t.Name, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(51));
        }

        [Fact]
        public void HouseholdUpdateRequest_ShouldAllow()
        {
            HouseholdUpdateRequestValidator sut = new HouseholdUpdateRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(37));

            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 9999);
            sut.ShouldNotHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(50));
        }

        [Fact]
        public void HouseholdUpdateRequest_ShouldValidate()
        {
            HouseholdUpdateRequestValidator sut = new HouseholdUpdateRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.ModifiedBy, StringGenerator.RandomString(37));

            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, -1);
            sut.ShouldHaveValidationErrorFor(t => t.Name, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Name, StringGenerator.RandomString(51));
        }
    }
}

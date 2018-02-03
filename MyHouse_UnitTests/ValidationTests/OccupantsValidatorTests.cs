using Xunit;
using MyHouseAPI.Validation;
using FluentValidation.TestHelper;
using MyHouseUnitTests.Helpers;

namespace MyHouseUnitTests.ValidationTests
{
    public class OccupantsValidatorTests
    {
        [Fact]
        public void OccupantInsertRequest_ShouldAllow()
        {
            OccupantInsertRequestValidator sut = new OccupantInsertRequestValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(28));
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(36));
        }

        [Fact]
        public void OccupantInsertRequest_ShouldValidate()
        {
            OccupantInsertRequestValidator sut = new OccupantInsertRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(37));
        }

        [Fact]
        public void OccupantResponse_ShouldAllow()
        {
            OccupantResponseValidator sut = new OccupantResponseValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(28));
            sut.ShouldNotHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(36));
            sut.ShouldNotHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(100));
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 9999);
        }

        [Fact]
        public void OccupantResponse_ShouldValidate()
        {
            OccupantResponseValidator sut = new OccupantResponseValidator();
            sut.ShouldHaveValidationErrorFor(t => t.UserId, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.UserId, "");
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(37));
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, "");
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(101));
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, -1);
        }
    }
}

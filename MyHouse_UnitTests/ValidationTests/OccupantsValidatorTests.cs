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

            sut.ShouldNotHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(28));
            sut.ShouldNotHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(36));
            sut.ShouldNotHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(100));
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 9999);
        }

        [Fact]
        public void OccupantInsertRequest_ShouldValidate()
        {
            OccupantInsertRequestValidator sut = new OccupantInsertRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(37));

            sut.ShouldHaveValidationErrorFor(t => t.UserId, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.UserId, "");
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(37));
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, "");
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(101));
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, -1);
        }

        [Fact]
        public void OccupantUpdateRequest_ShouldAllow()
        {
            OccupantUpdateRequestValidator sut = new OccupantUpdateRequestValidator();

            sut.ShouldNotHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(28));
            sut.ShouldNotHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(36));
            sut.ShouldNotHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(100));
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 9999);
        }

        [Fact]
        public void OccupantUpdateRequest_ShouldValidate()
        {
            OccupantUpdateRequestValidator sut = new OccupantUpdateRequestValidator();

            sut.ShouldHaveValidationErrorFor(t => t.UserId, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.UserId, "");
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(37));
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, "");
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(101));
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, -1);
        }
    }
}

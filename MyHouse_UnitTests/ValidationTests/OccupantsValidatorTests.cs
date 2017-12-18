using Xunit;
using MyHouseAPI.Validation;
using FluentValidation.TestHelper;
using MyHouseUnitTests.ValidationHelpers;

namespace MyHouseUnitTests.ValidationTests
{
    public class OccupantsValidatorTests
    {
        [Fact]
        public void OccupantsInsert_ShouldAllow()
        {
            OccupantsInsertValidator sut = new OccupantsInsertValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 9999);
        }

        [Fact]
        public void OccupantsInsert_ShouldValidate()
        {
            OccupantsInsertValidator sut = new OccupantsInsertValidator();
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, -1);
        }

        [Fact]
        public void Occupants_ShouldAllow()
        {
            OccupantsValidator sut = new OccupantsValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(36));
            sut.ShouldNotHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(100));
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 9999);
        }

        [Fact]
        public void Occupants_ShouldValidate()
        {
            OccupantsValidator sut = new OccupantsValidator();
            sut.ShouldHaveValidationErrorFor(t => t.UserId, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.UserId, "");
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(37));
            sut.ShouldHaveValidationErrorFor(t => t.UserId, StringGenerator.RandomString(35));
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, "");
            sut.ShouldHaveValidationErrorFor(t => t.DisplayName, StringGenerator.RandomString(101));
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, -1);
        }
    }
}

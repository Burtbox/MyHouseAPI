using Xunit;
using FluentValidation.TestHelper;
using MyHouseUnitTests.Helpers;
using MyHouseAPI.Validation.Houses;

namespace MyHouseUnitTests.ValidationTests
{
    public class NewsFeedValidatorTests
    {
        [Fact]
        public void NewsFeedInsertRequest_ShouldAllow()
        {
            NewsFeedInsertRequestValidator sut = new NewsFeedInsertRequestValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(28));
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(36));

            sut.ShouldNotHaveValidationErrorFor(t => t.Recipient, StringGenerator.RandomString(28));
            sut.ShouldNotHaveValidationErrorFor(t => t.Recipient, StringGenerator.RandomString(36));
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.OccupantId, 9999);

            sut.ShouldNotHaveValidationErrorFor(t => t.Headline, StringGenerator.RandomString(100));
            sut.ShouldNotHaveValidationErrorFor(t => t.SubHeadline, null as string);
            sut.ShouldNotHaveValidationErrorFor(t => t.SubHeadline, "");
            sut.ShouldNotHaveValidationErrorFor(t => t.SubHeadline, StringGenerator.RandomString(200));
            sut.ShouldNotHaveValidationErrorFor(t => t.Story, StringGenerator.RandomString(8001));
        }

        [Fact]
        public void NewsFeedInsertRequest_ShouldValidate()
        {
            NewsFeedInsertRequestValidator sut = new NewsFeedInsertRequestValidator();
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, StringGenerator.RandomString(37));

            sut.ShouldHaveValidationErrorFor(t => t.Recipient, StringGenerator.RandomString(27));
            sut.ShouldHaveValidationErrorFor(t => t.Recipient, StringGenerator.RandomString(37));
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.OccupantId, -1);

            sut.ShouldHaveValidationErrorFor(t => t.Headline, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Headline, "");
            sut.ShouldHaveValidationErrorFor(t => t.Headline, StringGenerator.RandomString(101));
            sut.ShouldHaveValidationErrorFor(t => t.SubHeadline, StringGenerator.RandomString(201));
            sut.ShouldHaveValidationErrorFor(t => t.Story, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Story, "");
            sut.ShouldHaveValidationErrorFor(t => t.Author, null as string);
            sut.ShouldHaveValidationErrorFor(t => t.Author, "");
            sut.ShouldHaveValidationErrorFor(t => t.Author, StringGenerator.RandomString(101));
        }
    }
}

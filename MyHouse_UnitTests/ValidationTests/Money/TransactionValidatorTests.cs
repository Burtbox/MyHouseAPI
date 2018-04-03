using Xunit;
using FluentValidation.TestHelper;
using MyHouseUnitTests.Helpers;
using MyHouseAPI.Validation.Houses;
using MyHouseAPI.Validation.Money;
using System;

namespace MyHouseUnitTests.ValidationTests
{
    public class TransactionValidatorTests
    {
        [Fact]
        public void TransactionInsertRequest_ShouldAllow()
        {
            TransactionInsertRequestValidator sut = new TransactionInsertRequestValidator();

            sut.ShouldNotHaveValidationErrorFor(t => t.Creditor, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.Creditor, 9999);
            sut.ShouldNotHaveValidationErrorFor(t => t.Debtor, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.Debtor, 9999);
            sut.ShouldNotHaveValidationErrorFor(t => t.Gross, NumberGenerator.RandomDecimal(17, 2));
            sut.ShouldNotHaveValidationErrorFor(t => t.Gross, NumberGenerator.RandomDecimal(2, 2));
            sut.ShouldNotHaveValidationErrorFor(t => t.Reference, StringGenerator.RandomString(200));
            sut.ShouldNotHaveValidationErrorFor(t => t.Date, DateTime.Now);
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.EnteredBy, 9999);
        }

        [Fact]
        public void TransactionInsertRequest_ShouldValidate()
        {
            TransactionInsertRequestValidator sut = new TransactionInsertRequestValidator();

            sut.ShouldHaveValidationErrorFor(t => t.Creditor, 0);
            sut.ShouldHaveValidationErrorFor(t => t.Creditor, -1);
            sut.ShouldHaveValidationErrorFor(t => t.Debtor, 0);
            sut.ShouldHaveValidationErrorFor(t => t.Debtor, -1);
            sut.ShouldHaveValidationErrorFor(t => t.Gross, NumberGenerator.RandomDecimal(19, 2));
            sut.ShouldHaveValidationErrorFor(t => t.Gross, -1 * NumberGenerator.RandomDecimal(19, 2));
            sut.ShouldHaveValidationErrorFor(t => t.Reference, StringGenerator.RandomString(201));
            sut.ShouldHaveValidationErrorFor(t => t.Date, DateTime.MinValue);
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, 0);
            sut.ShouldHaveValidationErrorFor(t => t.EnteredBy, -1);
        }
    }
}

using System;
using Xunit;
using MyHouseAPI.Validation;
using FluentValidation.TestHelper;

namespace MyHouseXunit.ValidationTests
{
    public class HouseholdsValidatorTests
    {
        [Fact]
        public void Households_ShouldAllow()
        {
            HouseholdsValidator sut = new HouseholdsValidator();
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 1);
            sut.ShouldNotHaveValidationErrorFor(t => t.HouseholdId, 9999);
        }

        [Fact]
        public void Households_ShouldValidate()
        {
            HouseholdsValidator sut = new HouseholdsValidator();
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, 0);
            sut.ShouldHaveValidationErrorFor(t => t.HouseholdId, -1);
        }
    }
}

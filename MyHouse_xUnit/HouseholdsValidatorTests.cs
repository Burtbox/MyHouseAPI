using System;
using Xunit;
using MyHouseAPI.Validation;

namespace MyHouseXunit.ValidationTests
{
    public class HouseholdsValidatorTests
    {
        [Fact]
        public void ValidHousehold()
        {
            HouseholdsValidator sut = new HouseholdsValidator();
            Assert.True(1 == 0);
        }
    }
}

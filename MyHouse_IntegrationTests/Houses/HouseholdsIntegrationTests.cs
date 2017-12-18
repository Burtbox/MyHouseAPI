using System;
using Xunit;
using FluentAssertions;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsIntegrationTests : BaseIntegrationTest
    {
        [Fact]
        public void Test1()
        {
            object bob = new { thing = "test" };

            bob.ShouldBeEquivalentTo(new { thing = "test" });
        }   
    }
}

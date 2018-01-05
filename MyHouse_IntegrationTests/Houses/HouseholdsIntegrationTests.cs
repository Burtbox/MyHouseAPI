using System;
using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsIntegrationTests : BaseIntegrationTest
    {
        [Fact]
        public void Test1()
        {
            var bob = apiCall();
            bob.ShouldBeEquivalentTo("");
        }   
    }
}

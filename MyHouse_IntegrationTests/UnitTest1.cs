using System;
using Xunit;
using FluentAssertions;

namespace MyHouse.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            object bob = new { thing = "test" };

            bob.ShouldBeEquivalentTo(new { thing = "test" });
        }   
    }
}

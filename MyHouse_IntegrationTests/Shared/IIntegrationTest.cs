using RestSharp;
using Xunit;

namespace MyHouseIntegrationTests.Shared
{
    public interface IIntegrationTest
    {
        string sutEndpoint { get; }
        Method sutHttpMethod { get; }

        [Fact]
        void InvalidHouseholdIdTest();

        [Fact]
        void InvalidUserIdTest();

        [Fact]
        void InvalidTokenTest();
    }
}

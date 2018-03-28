using Xunit;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model.Authorization;

namespace MyHouseIntegrationTests.Houses
{
    public class AuthorizationCheckIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Authorization;
        public Method sutHttpMethod => Method.GET;

        public AuthorizationCheckIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            // TODO: Implement!
        }

        public void InvalidHouseholdIdTest()
        {
            // NA
        }

        [Fact]
        public void InvalidUserIdTest()
        {

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId), sutHttpMethod);
            IRestResponse response = client.Execute<AuthorizationResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod);
            IRestResponse response = client.Execute<AuthorizationResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

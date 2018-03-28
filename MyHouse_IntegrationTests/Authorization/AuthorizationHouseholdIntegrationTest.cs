using Xunit;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model.Authorization;

namespace MyHouseIntegrationTests.Houses
{
    public class AuthorizationHouseholdIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Authorization;
        public Method sutHttpMethod => Method.GET;

        public AuthorizationHouseholdIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            // TODO: Implement!
        }

        public void InvalidHouseholdIdTest()
        {
            int householdId = 2;
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, householdId), sutHttpMethod);
            IRestResponse response = client.Execute<AuthorizationResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {

            int householdId = 1;
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, householdId), sutHttpMethod);
            IRestResponse response = client.Execute<AuthorizationResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int householdId = 1;
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, householdId), sutHttpMethod);
            IRestResponse response = client.Execute<AuthorizationResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

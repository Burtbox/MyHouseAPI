using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsDeleteIntegrationTests : BaseIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public HouseholdsDeleteIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        [Fact]
        public void DeleteHouseholdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H2UserId, ",", 2, ",", 5), Method.DELETE);
            IRestResponse response = client.Execute<int>(request);

            string expectedContent = string.Empty;

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H2UserId, ",", householdId), Method.DELETE);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdIdTest()
        {
            int householdId = 2;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.DELETE);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.DELETE);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

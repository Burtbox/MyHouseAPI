using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsGetIntegrationTests : BaseIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public HouseholdsGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        [Fact]
        public void GetHouseholdsOfHouseholdsTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H1UserId), Method.GET);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = serialize(new HouseholdResponse[]
            {
                new HouseholdResponse
                {
                    HouseholdId = 1,
                    Name = "Household 1 owner dickbutt",
                },
                new HouseholdResponse
                {
                    HouseholdId = 3,
                    Name = "Household 3 owner dickbutt",
                }
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H2UserId, ",", householdId), Method.GET);
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
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
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
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

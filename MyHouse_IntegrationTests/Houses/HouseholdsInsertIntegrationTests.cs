using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsInsertIntegrationTests : BaseIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public HouseholdsInsertIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        [Fact]
        public void InsertHouseholdTest()
        {
            string H4HouseholdName = StringGenerator.RandomString(100);
            HouseholdInsertRequest householdToInsert = new HouseholdInsertRequest
            {
                Name = H4HouseholdName,
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdInsertRequest>(firebaseFixture.H2Token, "Households/", Method.POST, householdToInsert);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = serialize(new HouseholdResponse
            {
                HouseholdId = 4,
                Name = H4HouseholdName
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H2UserId, ",", householdId), Method.POST);
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
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.POST);
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
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.POST);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

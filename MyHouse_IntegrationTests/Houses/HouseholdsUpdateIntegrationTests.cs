using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsUpdateIntegrationTests : BaseIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public HouseholdsUpdateIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        [Fact]
        public void UpdateHouseholdTest()
        {
            string H5HouseholdName = StringGenerator.RandomString(100);
            HouseholdUpdate householdToUpdate = new HouseholdUpdate
            {
                HouseholdId = 5,
                Name = H5HouseholdName,
                ModifiedBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdUpdate>(firebaseFixture.H2Token, "Households/", Method.PUT, householdToUpdate);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = serialize(new Household
            {
                HouseholdId = 5,
                Name = H5HouseholdName,
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H2UserId, ",", householdId), Method.PUT);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden); //TODO - generically check these three things? - maybe make a method for this. 
            response.Content.ShouldBeEquivalentTo(expectedContent); //Maybe just add these to base integration test ? 
        }

        [Fact]
        public void InvalidHouseholdIdTest()
        {
            int householdId = 2;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.PUT);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.PUT);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

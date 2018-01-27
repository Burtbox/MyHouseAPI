using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsIntegrationTests : BaseIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public HouseholdsIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        [Fact]
        public void GetHouseholdsOfHouseholdsTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H1UserId), Method.GET);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = serialize(new Household[]
            {
                new Household
                {
                    HouseholdId = 1,
                    Name = "Household 1 owner dickbutt",
                },
                new Household
                {
                    HouseholdId = 3,
                    Name = "Household 3 owner dickbutt",
                }
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InsertHouseholdTest()
        {
            string H4HouseholdName = StringGenerator.RandomString(100);
            HouseholdInsert householdToInsert = new HouseholdInsert
            {
                Name = H4HouseholdName,
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdInsert>(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H2UserId), Method.POST, householdToInsert);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = serialize(new Household
            {
                HouseholdId = 4,
                Name = H4HouseholdName
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
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
            RestRequest request = apiCall<HouseholdUpdate>(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H2UserId), Method.PUT, householdToUpdate);
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
        public void DeleteHouseholdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H2UserId, ",", 2, ",", 5), Method.DELETE);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = string.Empty;

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Households/", firebaseFixture.H2UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<Household>(request);

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
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Households/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<Household>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

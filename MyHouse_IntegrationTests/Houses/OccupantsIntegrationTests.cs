using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class OccupantsIntegrationTests : BaseIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public OccupantsIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        [Fact]
        public void GetOccupantsOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Occupants/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = serialize(new OccupantResponse[]
            {
                new OccupantResponse
                {
                    OccupantId = 1,
                    UserId = firebaseFixture.H1UserId,
                    DisplayName = "Household 1 owner dickbutt",
                    HouseholdId = 1
                },
                new OccupantResponse
                {
                    OccupantId = 2,
                    UserId = "zzrmi1i7nsApSvmeqA9QSIx1zwfs",
                    DisplayName = "O2DispName",
                    HouseholdId = 1
                }
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InsertOccupantTest()
        {
            string newUserId = StringGenerator.RandomString(28);
            string O4DisplayName = StringGenerator.RandomString(100);
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                UserId = newUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsertRequest>(firebaseFixture.H2Token, string.Concat("Occupants/", firebaseFixture.H2UserId), Method.POST, occupantToInsert);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = serialize(new OccupantResponse
            {
                OccupantId = 4,
                UserId = newUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void UpdateOccupantTest()
        {
            string currentUserId = "INPZD3OF1O47G19BUL1LwYAEx6JU";
            string O4DisplayName = StringGenerator.RandomString(100);
            OccupantResponse occupantToUpdate = new OccupantResponse
            {
                OccupantId = 5,
                UserId = currentUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsertRequest>(firebaseFixture.H2Token, string.Concat("Occupants/", firebaseFixture.H2UserId), Method.PUT, occupantToUpdate);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = serialize(new OccupantResponse
            {
                OccupantId = 5,
                UserId = currentUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void DeleteOccupantTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Occupants/", firebaseFixture.H2UserId, ",", 2, ",", 5), Method.DELETE);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = string.Empty;

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Occupants/", firebaseFixture.H2UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdIdTest()
        {
            int householdId = 2;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Occupants/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Occupants/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = string.Empty;
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

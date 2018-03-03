using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class OccupantsDeleteIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Occupants;
        public Method sutHttpMethod => Method.DELETE;

        public OccupantsDeleteIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        private int CreateOccupantToDelete()
        {
            string newUserId = StringGenerator.RandomString(28);
            string newDisplayName = StringGenerator.RandomString(100);
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                UserId = newUserId,
                DisplayName = newDisplayName,
                HouseholdId = 2,
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsertRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse<OccupantResponse> response = client.Execute<OccupantResponse>(request);

            return response.Data.OccupantId;
        }

        //[Fact]
        public void DeleteOccupantTest()
        {
            int householdId = 2;
            int occupantId = CreateOccupantToDelete();
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", householdId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            string expectedContent = string.Empty;

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        //[Fact]
        public void InvalidHouseholdIdTest()
        {
            int householdId = 1;
            int occupantId = 3;
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", householdId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }

        //[Fact]
        public void InvalidUserIdTest()
        {
            int householdId = 1;
            int occupantId = 3;
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", householdId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }

        //[Fact]
        public void InvalidTokenTest()
        {
            int householdId = 2;
            int occupantId = 5;
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", householdId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

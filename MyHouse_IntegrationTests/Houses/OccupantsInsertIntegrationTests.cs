using System.Net;
using FluentAssertions;
using MyHouseAPI.Model;
using MyHouseIntegrationTests.Shared;
using MyHouseUnitTests.Helpers;
using RestSharp;
using Xunit;

namespace MyHouseIntegrationTests.Houses
{
    public class OccupantsInsertIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => "Occupants/";
        public Method sutHttpMethod => Method.POST;

        public OccupantsInsertIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

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
            RestRequest request = apiCall<OccupantInsertRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
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
        public void InvalidHouseholdIdTest()
        {
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }
    }
}
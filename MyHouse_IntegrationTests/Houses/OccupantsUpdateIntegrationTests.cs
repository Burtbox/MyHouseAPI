using System.Net;
using FluentAssertions;
using MyHouseAPI.Model;
using MyHouseIntegrationTests.Shared;
using MyHouseUnitTests.Helpers;
using RestSharp;
using Xunit;

namespace MyHouseIntegrationTests.Houses
{
    public class OccupantsUpdateIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => "EndpointsEnum.Occupants";
        public Method sutHttpMethod => Method.PUT;

        public OccupantsUpdateIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void UpdateOccupantTest()
        {
            string O4DisplayName = StringGenerator.RandomString(100);
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                UserId = firebaseFixture.H2UserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantUpdateRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
            IRestResponse<OccupantResponse> response = client.Execute<OccupantResponse>(request);

            string expectedContent = serialize(new OccupantResponse
            {
                OccupantId = 2,
                UserId = firebaseFixture.H2UserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdIdTest()
        {
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                UserId = firebaseFixture.H2UserId,
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                UserId = firebaseFixture.H1UserId,
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                UserId = firebaseFixture.H2UserId,
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }
    }
}
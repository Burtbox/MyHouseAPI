using System.Net;
using FluentAssertions;
using MyHouseAPI.Model.Houses;
using MyHouseIntegrationTests.Shared;
using MyHouseUnitTests.Helpers;
using RestSharp;
using Xunit;

namespace MyHouseIntegrationTests.Houses
{
    public class OccupantsInsertIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.OccupantsInsert;
        public Method sutHttpMethod => Method.POST;

        public OccupantsInsertIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void InsertOccupantTest()
        {
            string newUserId = StringGenerator.RandomString(28);
            string O4DisplayName = StringGenerator.RandomString(100);
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                InviteAccepted = false,
                UserId = newUserId,
                DisplayName = O4DisplayName,
                EnteredBy = firebaseFixture.H2UserId,
                InvitedByOccupantId = 2,
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsertRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse<OccupantResponse> response = client.Execute<OccupantResponse>(request);

            string expectedContent = serialize(new OccupantResponse
            {
                OccupantId = response.Data != null ? response.Data.OccupantId : 0,
                UserId = newUserId,
                DisplayName = O4DisplayName,
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Data.OccupantId.Should().BePositive();
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                InviteAccepted = false,
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                InvitedByOccupantId = 1,
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            OccupantInsertRequest occupantToInsert = new OccupantInsertRequest
            {
                InviteAccepted = false,
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                InvitedByOccupantId = 1,
                EnteredBy = firebaseFixture.H1UserId
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
                InviteAccepted = false,
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                InvitedByOccupantId = 2,
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }
    }
}
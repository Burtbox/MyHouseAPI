using System.Net;
using FluentAssertions;
using MyHouseAPI.Model.Houses;
using MyHouseIntegrationTests.Shared;
using MyHouseUnitTests.Helpers;
using RestSharp;
using Xunit;

namespace MyHouseIntegrationTests.Houses
{
    public class OccupantsInviteIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.OccupantsInvite;
        public Method sutHttpMethod => Method.POST;

        public OccupantsInviteIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        // TODO: Split into existing user and new user tests
        [Fact]
        public void InviteOccupantTest()
        {
            OccupantInviteRequest occupantToInsert = new OccupantInviteRequest
            {
                Email = firebaseFixture.H3Email,
                InvitedByUserId = firebaseFixture.H2UserId,
                InvitedByOccupantId = firebaseFixture.H2OccupantId,
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInviteRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse<OccupantInviteResponse> response = client.Execute<OccupantInviteResponse>(request);

            string expectedContent = serialize(new OccupantInviteResponse
            {
                Email = firebaseFixture.H3Email,
                EmailVerified = false,
                Uid = firebaseFixture.H3UserId,
                DisplayName = firebaseFixture.H3DisplayName
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            OccupantInviteRequest occupantToInsert = new OccupantInviteRequest
            {
                Email = firebaseFixture.H1Email,
                InvitedByUserId = firebaseFixture.H2UserId,
                InvitedByOccupantId = firebaseFixture.H1OccupantId,
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantInviteResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            OccupantInviteRequest occupantToInsert = new OccupantInviteRequest
            {
                Email = firebaseFixture.H1Email,
                InvitedByUserId = firebaseFixture.H1UserId,
                InvitedByOccupantId = firebaseFixture.H2OccupantId,
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantInviteResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            OccupantInviteRequest occupantToInsert = new OccupantInviteRequest
            {
                Email = firebaseFixture.H1Email,
                InvitedByUserId = firebaseFixture.H2UserId,
                InvitedByOccupantId = firebaseFixture.H2OccupantId,
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, occupantToInsert);
            IRestResponse response = client.Execute<OccupantInviteResponse>(request);

            forbiddenExpectations(response);
        }
    }
}
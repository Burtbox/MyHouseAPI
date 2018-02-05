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
        public string sutEndpoint => "Occupants/";
        public Method sutHttpMethod => Method.PUT;

        public OccupantsUpdateIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void UpdateOccupantTest()
        {
            string currentUserId = "INPZD3OF1O47G19BUL1LwYAEx6JU"; //TODO: check other users can't edit others'
            string O4DisplayName = StringGenerator.RandomString(100);
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                OccupantId = 5,
                UserId = currentUserId, //TODO: combine this and modified by
                DisplayName = O4DisplayName,
                HouseholdId = 2,
                ModifiedBy = currentUserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantUpdateRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
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
        public void InvalidHouseholdIdTest()
        {
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                OccupantId = 5,
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 1,
                ModifiedBy = StringGenerator.RandomString(28)
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                OccupantId = 5,
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 1,
                ModifiedBy = StringGenerator.RandomString(28)
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            OccupantUpdateRequest occupantToUpdate = new OccupantUpdateRequest
            {
                OccupantId = 5,
                UserId = StringGenerator.RandomString(28),
                DisplayName = StringGenerator.RandomString(100),
                HouseholdId = 2,
                ModifiedBy = StringGenerator.RandomString(28)
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, occupantToUpdate);
            IRestResponse response = client.Execute<OccupantResponse>(request);

            forbiddenExpectations(response);
        }
    }
}
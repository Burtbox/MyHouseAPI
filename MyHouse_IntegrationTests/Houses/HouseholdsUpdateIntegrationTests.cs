using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsUpdateIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public HouseholdsUpdateIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        private string householdsEndpoint = "Households/";

        [Fact]
        public void UpdateHouseholdTest()
        {
            string H5HouseholdName = StringGenerator.RandomString(100);
            HouseholdUpdateRequest householdToUpdate = new HouseholdUpdateRequest
            {
                HouseholdId = 5,
                Name = H5HouseholdName,
                ModifiedBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdUpdateRequest>(firebaseFixture.H2Token, householdsEndpoint, Method.PUT, householdToUpdate);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = serialize(new HouseholdResponse
            {
                HouseholdId = 5,
                Name = H5HouseholdName,
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(householdsEndpoint, firebaseFixture.H1UserId, ",", householdId), Method.PUT);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(householdsEndpoint, firebaseFixture.H2UserId, ",", householdId), Method.PUT);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidHouseholdIdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(householdsEndpoint, string.Concat(firebaseFixture.H1UserId, ",", 2)), Method.PUT);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }
    }
}

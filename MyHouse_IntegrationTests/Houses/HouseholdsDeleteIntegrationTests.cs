using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsDeleteIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Households;
        public Method sutHttpMethod => Method.DELETE;

        public HouseholdsDeleteIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        private int CreateHouseholdToDelete()
        {
            string HouseholdName = StringGenerator.RandomString(50);
            HouseholdInsertRequest householdToInsert = new HouseholdInsertRequest
            {
                Name = HouseholdName,
                EnteredBy = firebaseFixture.H2UserId,
                CreatorDisplayName = firebaseFixture.H2DisplayName
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdInsertRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, householdToInsert);
            IRestResponse<HouseholdResponse> response = client.Execute<HouseholdResponse>(request);

            return response.Data.OccupantId;
        }

        //[Fact]
        public void DeleteHouseholdTest()
        {
            int householdId = CreateHouseholdToDelete();

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", householdId), sutHttpMethod);
            IRestResponse response = client.Execute<int>(request);

            forbiddenExpectations(response);
        }

        //[Fact]
        public void InvalidOccupantIdTest()
        {
            int occupantId = 2;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }

        //[Fact]
        public void InvalidUserIdTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }

        //[Fact]
        public void InvalidTokenTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

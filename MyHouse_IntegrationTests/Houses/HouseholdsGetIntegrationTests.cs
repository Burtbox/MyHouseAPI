using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsGetIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Households;
        public Method sutHttpMethod => Method.GET;

        public HouseholdsGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void GetHouseholdsOfOccupantTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = serialize(new HouseholdResponse[]
            {
                new HouseholdResponse
                {
                    OccupantId = 1,
                    Name = "Household 1 owner dickbutt",
                },
                new HouseholdResponse
                {
                    OccupantId = 7,
                    Name = "Household 3 owner dickbutt",
                }
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            int occupantId = 2;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
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

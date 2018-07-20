using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using System.Net;
using MyHouseAPI.Model.Houses;

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
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod);
            request.AddParameter("userId", firebaseFixture.H1UserId);
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
                    OccupantId = 8,
                    Name = "Household 3 owner dickbutt",
                },
                new HouseholdResponse
                {
                    OccupantId = 14,
                    Name = "Household 6 owner dickbutt3"
                }
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void GetHouseholdsOfOccupantIncludingInvitesTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod);
            request.AddQueryParameter("userId", firebaseFixture.H1UserId);
            request.AddQueryParameter("includeInvites", "True");
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
                    OccupantId = 8,
                    Name = "Household 3 owner dickbutt",
                },
                new HouseholdResponse
                {
                    OccupantId = 14,
                    Name = "Household 6 owner dickbutt3"
                },
                new HouseholdResponse
                {
                    OccupantId = 18,
                    Name = "TEST PENDING INVITE HERE ED"
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
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod);
            request.AddParameter("userId", firebaseFixture.H1UserId);
            request.AddParameter("occupantId", occupantId);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod);
            request.AddParameter("userId", firebaseFixture.H2UserId);
            request.AddParameter("occupantId", occupantId);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod);
            request.AddParameter("userId", firebaseFixture.H1UserId);
            request.AddParameter("occupantId", occupantId);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

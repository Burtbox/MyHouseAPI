using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class BalanceGetIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Balance;
        public Method sutHttpMethod => Method.GET;

        public BalanceGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void GetBalanceOfOccupantTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            string expectedContent = serialize(new BalanceResponse[]
            {
                new BalanceResponse
                {
                    Creditor = "dickbutt",
                    Debtor = "Household 1 occupant O2DispName",
                    Gross = new decimal(4.20)
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
            IRestResponse response = client.Execute<BalanceResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int occupantId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

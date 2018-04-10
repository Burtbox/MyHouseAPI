using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using System.Net;
using MyHouseAPI.Model.Money;

namespace MyHouseIntegrationTests.Money
{
    public class BalanceGetIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Balance;
        public Method sutHttpMethod => Method.GET;

        public BalanceGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void GetBalanceOfOccupantTest()
        {
            int occupantId = firebaseFixture.H3OccupantId;
            string displayName = firebaseFixture.H3DisplayName;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H3Token, string.Concat(sutEndpoint, firebaseFixture.H3UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            string expectedContent = serialize(new BalanceResponse[]
            {
                new BalanceResponse
                {
                    CreditorDisplayName = displayName,
                    CreditorOccupantId = occupantId,
                    DebtorDisplayName = "Household 3 Bal Test 1",
                    DebtorOccupantId = 12,
                    Gross = decimal.Parse("-0.04")
                },
                new BalanceResponse
                {
                    CreditorDisplayName = displayName,
                    CreditorOccupantId = occupantId,
                    DebtorDisplayName = "Household 3 Bal Test 2",
                    DebtorOccupantId = 11,
                    Gross = decimal.Parse("4.22")
                },
                new BalanceResponse
                {
                    CreditorDisplayName = displayName,
                    CreditorOccupantId = occupantId,
                    DebtorDisplayName = "Household 3 Bal Test 3",
                    DebtorOccupantId = 12,
                    Gross = decimal.Parse("0.00")
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

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
            int occupantId = firebaseFixture.H2OccupantId;
            string displayName = firebaseFixture.H2DisplayName;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", occupantId), sutHttpMethod);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            string expectedContent = serialize(new BalanceResponse[]
            {
                new BalanceResponse
                {
                    CreditorDisplayName = displayName,
                    CreditorOccupantId = occupantId,
                    DebtorDisplayName = "Household 2 occupant O2DispName",
                    DebtorOccupantId = 4,
                    Gross = decimal.Parse("-0.04")
                },
                new BalanceResponse
                {
                    CreditorDisplayName = displayName,
                    CreditorOccupantId = occupantId,
                    DebtorDisplayName = "Household 2 occupant put",
                    DebtorOccupantId = 5,
                    Gross = decimal.Parse("4.22")
                },
                new BalanceResponse
                {
                    CreditorDisplayName = displayName,
                    CreditorOccupantId = occupantId,
                    DebtorDisplayName = "Household 2 occupant delete",
                    DebtorOccupantId = 6,
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

using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using System.Net;
using MyHouseAPI.Model.Money;
using System.Collections.Generic;
using System;

namespace MyHouseIntegrationTests.Money
{
    public class TransactionSummaryGetIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.TransactionSummary;
        public Method sutHttpMethod => Method.GET;

        public TransactionSummaryGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void GetTransactionSummaryTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H3Token, string.Concat(sutEndpoint, firebaseFixture.H3UserId, ",", 13), sutHttpMethod);
            IRestResponse<List<TransactionSummaryResponse>> response = client.Execute<List<TransactionSummaryResponse>>(request);

            string expectedContent = serialize(this.GetTransactionSummaryRows());

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", firebaseFixture.H3OccupantId), sutHttpMethod);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", firebaseFixture.H1OccupantId), sutHttpMethod);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", firebaseFixture.H1OccupantId), sutHttpMethod);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        private TransactionSummaryResponse[] GetTransactionSummaryRows()
        {
            int expectedHouseholdId = 6;
            return new TransactionSummaryResponse[] {
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 13,
                    CreditorDisplayName = firebaseFixture.H3DisplayName,
                    DebtorOccupantId = 13,
                    DebtorDisplayName = firebaseFixture.H3DisplayName,
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 13,
                    CreditorDisplayName = firebaseFixture.H3DisplayName,
                    DebtorOccupantId = 14,
                    DebtorDisplayName = firebaseFixture.H1DisplayName,
                    Gross = decimal.Parse("-3.40"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 13,
                    CreditorDisplayName = firebaseFixture.H3DisplayName,
                    DebtorOccupantId = 15,
                    DebtorDisplayName = "Transaction History DU1",
                    Gross = decimal.Parse("-12.65"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 13,
                    CreditorDisplayName = firebaseFixture.H3DisplayName,
                    DebtorOccupantId = 16,
                    DebtorDisplayName = "Transaction History DU2",
                    Gross = decimal.Parse("166.59"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 14,
                    CreditorDisplayName = firebaseFixture.H1DisplayName,
                    DebtorOccupantId = 13,
                    DebtorDisplayName = firebaseFixture.H3DisplayName,
                    Gross = decimal.Parse("3.40"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 14,
                    CreditorDisplayName = firebaseFixture.H1DisplayName,
                    DebtorOccupantId = 14,
                    DebtorDisplayName = firebaseFixture.H1DisplayName,
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 14,
                    CreditorDisplayName = firebaseFixture.H1DisplayName,
                    DebtorOccupantId = 15,
                    DebtorDisplayName = "Transaction History DU1",
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 14,
                    CreditorDisplayName = firebaseFixture.H1DisplayName,
                    DebtorOccupantId = 16,
                    DebtorDisplayName = "Transaction History DU2",
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 15,
                    CreditorDisplayName = "Transaction History DU1",
                    DebtorOccupantId = 13,
                    DebtorDisplayName = firebaseFixture.H3DisplayName,
                    Gross = decimal.Parse("12.65"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 15,
                    CreditorDisplayName = "Transaction History DU1",
                    DebtorOccupantId = 14,
                    DebtorDisplayName = firebaseFixture.H1DisplayName,
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 15,
                    CreditorDisplayName = "Transaction History DU1",
                    DebtorOccupantId = 15,
                    DebtorDisplayName = "Transaction History DU1",
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 15,
                    CreditorDisplayName = "Transaction History DU1",
                    DebtorOccupantId = 16,
                    DebtorDisplayName = "Transaction History DU2",
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 16,
                    CreditorDisplayName = "Transaction History DU2",
                    DebtorOccupantId = 13,
                    DebtorDisplayName = firebaseFixture.H3DisplayName,
                    Gross = decimal.Parse("-166.59"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 16,
                    CreditorDisplayName = "Transaction History DU2",
                    DebtorOccupantId = 14,
                    DebtorDisplayName = firebaseFixture.H1DisplayName,
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 16,
                    CreditorDisplayName = "Transaction History DU2",
                    DebtorOccupantId = 15,
                    DebtorDisplayName = "Transaction History DU1",
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
                new TransactionSummaryResponse
                {
                    CreditorOccupantId = 16,
                    CreditorDisplayName = "Transaction History DU2",
                    DebtorOccupantId = 16,
                    DebtorDisplayName = "Transaction History DU2",
                    Gross = decimal.Parse("0.00"),
                    DebtorHouseholdId = expectedHouseholdId,
                    CreditorHouseholdId = expectedHouseholdId,
                },
            };
        }
    }
}

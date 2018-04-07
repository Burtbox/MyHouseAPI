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
    public class TransactionHistoryGetIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Transactions;
        public Method sutHttpMethod => Method.GET;

        public TransactionHistoryGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void GetTransactionHistoryTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H3Token, string.Concat(sutEndpoint, firebaseFixture.H3UserId, ",", 13), sutHttpMethod);
            IRestResponse<List<TransactionHistoryResponse>> response = client.Execute<List<TransactionHistoryResponse>>(request);

            string expectedContent = serialize(new TransactionHistoryResponse[]
                {
                    new TransactionHistoryResponse {
                        TransactionId = response.Data[0].TransactionId,
                        CreditorOccupantId = 13,
                        CreditorDisplayName = firebaseFixture.H3DisplayName,
                        DebtorOccupantId = 15,
                        DebtorDisplayName = "Transaction History DU1",
                        Gross = decimal.Parse("1.11"),
                        Date = DateTime.Parse("2018-04-07"),
                        Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)",
                        EnteredByOccupantId = 13,
                        EnteredByDisplayName = firebaseFixture.H3DisplayName,
                        EnteredDate = response.Data[0].EnteredDate
                    },
                    new TransactionHistoryResponse {
                        TransactionId = response.Data[1].TransactionId,
                        CreditorOccupantId = 13,
                        CreditorDisplayName = firebaseFixture.H3DisplayName,
                        DebtorOccupantId = 15,
                        DebtorDisplayName = "Transaction History DU1",
                        Gross = decimal.Parse("-15.76"),
                        Date = DateTime.Parse("2018-04-09"),
                        Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)",
                        EnteredByOccupantId = 13,
                        EnteredByDisplayName = firebaseFixture.H3DisplayName,
                        EnteredDate = response.Data[1].EnteredDate
                    },
                    new TransactionHistoryResponse {
                        TransactionId = response.Data[2].TransactionId,
                        CreditorOccupantId = 13,
                        CreditorDisplayName = firebaseFixture.H3DisplayName,
                        DebtorOccupantId = 16,
                        DebtorDisplayName = "Transaction History DU2",
                        Gross = decimal.Parse("166.59"),
                        Date = DateTime.Parse("2018-04-11"),
                        Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU2(16)",
                        EnteredByOccupantId = 13,
                        EnteredByDisplayName = firebaseFixture.H3DisplayName,
                        EnteredDate = response.Data[2].EnteredDate
                    },
                    new TransactionHistoryResponse {
                        TransactionId = response.Data[3].TransactionId,
                        CreditorOccupantId = 13,
                        CreditorDisplayName = firebaseFixture.H3DisplayName,
                        DebtorOccupantId = 15,
                        DebtorDisplayName = "Transaction History DU1",
                        Gross = decimal.Parse("2.00"),
                        Date = DateTime.Parse("2018-04-21"),
                        Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)",
                        EnteredByOccupantId = 13,
                        EnteredByDisplayName = firebaseFixture.H3DisplayName,
                        EnteredDate = response.Data[3].EnteredDate
                    },
                    new TransactionHistoryResponse {
                        TransactionId = response.Data[4].TransactionId,
                        CreditorOccupantId = 13,
                        CreditorDisplayName = firebaseFixture.H3DisplayName,
                        DebtorOccupantId = 14,
                        DebtorDisplayName = firebaseFixture.H1DisplayName,
                        Gross = decimal.Parse("-3.40"),
                        Date = DateTime.Parse("2018-12-10"),
                        Reference = "Test Tran Between dickbutt(1) and dickbutt3(3)",
                        EnteredByOccupantId = 14,
                        EnteredByDisplayName = firebaseFixture.H1DisplayName,
                        EnteredDate = response.Data[4].EnteredDate
                    }
                }
            );

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
            // TODO: Add separate check for entered date about right - will need some tolerance built in, write a helper for this!
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
    }
}

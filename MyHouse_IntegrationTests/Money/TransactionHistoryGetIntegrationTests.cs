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
        public string sutEndpoint => EndpointsEnum.TransactionHistory;
        public Method sutHttpMethod => Method.GET;

        public TransactionHistoryGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void GetTransactionHistoryTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H3Token, string.Concat(sutEndpoint, firebaseFixture.H3UserId, ",", 13, ",", 5, ",", 1), sutHttpMethod);
            IRestResponse<List<TransactionHistoryResponse>> response = client.Execute<List<TransactionHistoryResponse>>(request);

            string expectedContent = serialize(new TransactionHistoryResponse[]
                {
                    this.GetTransactionHistoryTran1(response, 0),
                    this.GetTransactionHistoryTran2(response, 1),
                    this.GetTransactionHistoryTran3(response, 2),
                    this.GetTransactionHistoryTran4(response, 3),
                    this.GetTransactionHistoryTran5(response, 4),
                }
            );

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void GetTransactionHistoryPage1Test()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H3Token, string.Concat(sutEndpoint, firebaseFixture.H3UserId, ",", 13, ",", 1, ",", 1), sutHttpMethod);
            IRestResponse<List<TransactionHistoryResponse>> response = client.Execute<List<TransactionHistoryResponse>>(request);

            string expectedContent = serialize(new TransactionHistoryResponse[]
                {
                    this.GetTransactionHistoryTran1(response, 0)
                }
            );

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void GetTransactionHistoryPage2Test()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H3Token, string.Concat(sutEndpoint, firebaseFixture.H3UserId, ",", 13, ",", 3, ",", 2), sutHttpMethod);
            IRestResponse<List<TransactionHistoryResponse>> response = client.Execute<List<TransactionHistoryResponse>>(request);

            string expectedContent = serialize(new TransactionHistoryResponse[]
                {
                    GetTransactionHistoryTran4(response, 0),
                    GetTransactionHistoryTran5(response, 1)
                }
            );

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void GetTransactionHistoryPage3Test()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H3Token, string.Concat(sutEndpoint, firebaseFixture.H3UserId, ",", 13, ",", 2, ",", 3), sutHttpMethod);
            IRestResponse<List<TransactionHistoryResponse>> response = client.Execute<List<TransactionHistoryResponse>>(request);

            string expectedContent = serialize(new TransactionHistoryResponse[]
                {
                    this.GetTransactionHistoryTran5(response, 0),
                }
            );

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", firebaseFixture.H3OccupantId, ",", 1, ",", 1), sutHttpMethod);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", firebaseFixture.H1OccupantId, ",", 1, ",", 1), sutHttpMethod);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", firebaseFixture.H1OccupantId, ",", 1, ",", 1), sutHttpMethod);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        private TransactionHistoryResponse GetTransactionHistoryTran1(IRestResponse<List<TransactionHistoryResponse>> response, int rowNumber)
        {
            return new TransactionHistoryResponse
            {
                TransactionId = response.Data[rowNumber].TransactionId,
                CreditorOccupantId = 13,
                CreditorDisplayName = firebaseFixture.H3DisplayName,
                DebtorOccupantId = 14,
                DebtorDisplayName = firebaseFixture.H1DisplayName,
                Gross = decimal.Parse("-3.40"),
                Date = DateTime.Parse("2018-12-10"),
                Reference = "Test Tran Between dickbutt(1) and dickbutt3(3)",
                EnteredByOccupantId = 14,
                EnteredByDisplayName = firebaseFixture.H1DisplayName,
                EnteredDate = response.Data[rowNumber].EnteredDate
            };
        }

        private TransactionHistoryResponse GetTransactionHistoryTran2(IRestResponse<List<TransactionHistoryResponse>> response, int rowNumber)
        {
            return new TransactionHistoryResponse
            {
                TransactionId = response.Data[rowNumber].TransactionId,
                CreditorOccupantId = 13,
                CreditorDisplayName = firebaseFixture.H3DisplayName,
                DebtorOccupantId = 15,
                DebtorDisplayName = "Transaction History DU1",
                Gross = decimal.Parse("2.00"),
                Date = DateTime.Parse("2018-04-21"),
                Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)",
                EnteredByOccupantId = 13,
                EnteredByDisplayName = firebaseFixture.H3DisplayName,
                EnteredDate = response.Data[rowNumber].EnteredDate
            };
        }

        private TransactionHistoryResponse GetTransactionHistoryTran3(IRestResponse<List<TransactionHistoryResponse>> response, int rowNumber)
        {
            return new TransactionHistoryResponse
            {
                TransactionId = response.Data[rowNumber].TransactionId,
                CreditorOccupantId = 13,
                CreditorDisplayName = firebaseFixture.H3DisplayName,
                DebtorOccupantId = 16,
                DebtorDisplayName = "Transaction History DU2",
                Gross = decimal.Parse("166.59"),
                Date = DateTime.Parse("2018-04-11"),
                Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU2(16)",
                EnteredByOccupantId = 13,
                EnteredByDisplayName = firebaseFixture.H3DisplayName,
                EnteredDate = response.Data[rowNumber].EnteredDate
            };
        }

        private TransactionHistoryResponse GetTransactionHistoryTran4(IRestResponse<List<TransactionHistoryResponse>> response, int rowNumber)
        {
            return new TransactionHistoryResponse
            {
                TransactionId = response.Data[rowNumber].TransactionId,
                CreditorOccupantId = 13,
                CreditorDisplayName = firebaseFixture.H3DisplayName,
                DebtorOccupantId = 15,
                DebtorDisplayName = "Transaction History DU1",
                Gross = decimal.Parse("-15.76"),
                Date = DateTime.Parse("2018-04-09"),
                Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)",
                EnteredByOccupantId = 13,
                EnteredByDisplayName = firebaseFixture.H3DisplayName,
                EnteredDate = response.Data[rowNumber].EnteredDate
            };
        }

        private TransactionHistoryResponse GetTransactionHistoryTran5(IRestResponse<List<TransactionHistoryResponse>> response, int rowNumber)
        {
            return new TransactionHistoryResponse
            {
                TransactionId = response.Data[rowNumber].TransactionId,
                CreditorOccupantId = 13,
                CreditorDisplayName = firebaseFixture.H3DisplayName,
                DebtorOccupantId = 15,
                DebtorDisplayName = "Transaction History DU1",
                Gross = decimal.Parse("1.11"),
                Date = DateTime.Parse("2018-04-07"),
                Reference = "Test Tran Between dickbutt3(3) and Household 6 occupant Transaction History DU1(15)",
                EnteredByOccupantId = 13,
                EnteredByDisplayName = firebaseFixture.H3DisplayName,
                EnteredDate = response.Data[rowNumber].EnteredDate
            };
        }
    }
}

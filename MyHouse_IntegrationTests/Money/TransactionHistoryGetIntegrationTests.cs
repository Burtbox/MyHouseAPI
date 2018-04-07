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
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId, ",", firebaseFixture.H2OccupantId), sutHttpMethod);
            IRestResponse<List<TransactionResponse>> response = client.Execute<List<TransactionResponse>>(request);

            string expectedContent = serialize(new TransactionResponse[]
                {
                    new TransactionResponse {
                        TransactionId = response.Data[0].TransactionId,
                        CreditorOccupantId = firebaseFixture.H2OccupantId,
                        DebtorOccupantId = 5,
                        Gross = decimal.Parse("1.11"),
                        Date = DateTime.Parse("2018-04-07"),
                        Reference = "Test Tran Between dickbutt2(2) and Household 2 occupant O2DispName(5)"
                    },
                    new TransactionResponse {
                        TransactionId = response.Data[1].TransactionId,
                        CreditorOccupantId = firebaseFixture.H2OccupantId,
                        DebtorOccupantId = 5,
                        Gross = decimal.Parse("-15.76"),
                        Date = DateTime.Parse("2018-04-09"),
                        Reference = "Test Tran Between dickbutt2(2) and Household 2 occupant O2DispName(5)"
                    },
                    new TransactionResponse {
                        TransactionId = response.Data[2].TransactionId,
                        CreditorOccupantId = firebaseFixture.H2OccupantId,
                        DebtorOccupantId = 6,
                        Gross = decimal.Parse("166.59"),
                        Date = DateTime.Parse("2018-04-11"),
                        Reference = "Test Tran Between dickbutt2(2) and Household 2 occupant put(6)"
                    },
                    new TransactionResponse {
                        TransactionId = response.Data[3].TransactionId,
                        CreditorOccupantId = firebaseFixture.H2OccupantId,
                        DebtorOccupantId = 5,
                        Gross = decimal.Parse("2.00"),
                        Date = DateTime.Parse("2018-04-21"),
                        Reference = "Test Tran Between dickbutt2(2) and Household 2 occupant O2DispName(5)"
                    },
                    new TransactionResponse {
                        TransactionId = response.Data[4].TransactionId,
                        CreditorOccupantId = firebaseFixture.H3OccupantId,
                        DebtorOccupantId = firebaseFixture.H2OccupantId,
                        Gross = decimal.Parse("3.40"),
                        Date = DateTime.Parse("2018-12-10"),
                        Reference = "Test Tran Between dickbutt3(3) and dickbutt2(2)"
                    }
                }
            );

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId, ",", firebaseFixture.H2OccupantId), sutHttpMethod);
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

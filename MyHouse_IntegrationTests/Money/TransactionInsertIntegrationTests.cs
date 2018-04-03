using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using System.Net;
using MyHouseAPI.Model.Money;
using MyHouseUnitTests.Helpers;
using System;

namespace MyHouseIntegrationTests.Money
{
    public class TransactionInsertIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.Transactions;
        public Method sutHttpMethod => Method.POST;

        public TransactionInsertIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void AddTransactionTest()
        {
            decimal gross = NumberGenerator.RandomDecimal(17, 2);
            string reference = StringGenerator.RandomString(200);
            DateTime date = DateTime.Now;
            TransactionInsertRequest transactionToInsert = new TransactionInsertRequest
            {
                Creditor = 1,
                Debtor = 3,
                Gross = gross,
                Reference = reference,
                Date = date,
                EnteredBy = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<TransactionInsertRequest>(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod, transactionToInsert);
            IRestResponse<TransactionResponse> response = client.Execute<TransactionResponse>(request);

            string expectedContent = serialize(new TransactionResponse
            {
                TransactionId = response.Data.TransactionId,
                Creditor = 1,
                Debtor = 3,
                Gross = gross,
                Reference = reference,
                Date = date,
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {

            TransactionInsertRequest transactionToInsert = new TransactionInsertRequest
            {
                Creditor = 1,
                Debtor = 3,
                Gross = NumberGenerator.RandomDecimal(17, 2),
                Reference = StringGenerator.RandomString(200),
                Date = DateTime.Now,
                EnteredBy = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod, transactionToInsert);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            TransactionInsertRequest transactionToInsert = new TransactionInsertRequest
            {
                Creditor = 1,
                Debtor = 3,
                Gross = NumberGenerator.RandomDecimal(17, 2),
                Reference = StringGenerator.RandomString(200),
                Date = DateTime.Now,
                EnteredBy = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId), sutHttpMethod, transactionToInsert);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            TransactionInsertRequest transactionToInsert = new TransactionInsertRequest
            {
                Creditor = 1,
                Debtor = 3,
                Gross = NumberGenerator.RandomDecimal(17, 2),
                Reference = StringGenerator.RandomString(200),
                Date = DateTime.Now,
                EnteredBy = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod, transactionToInsert);
            IRestResponse response = client.Execute<BalanceResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

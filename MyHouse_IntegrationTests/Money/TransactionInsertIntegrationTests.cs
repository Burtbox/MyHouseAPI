using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using System.Net;
using MyHouseAPI.Model.Money;
using MyHouseUnitTests.Helpers;
using System;
using System.Collections.Generic;

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
            decimal gross = NumberGenerator.RandomDecimal(16, 2);
            decimal gross2 = NumberGenerator.RandomDecimal(16, 2);
            string reference = StringGenerator.RandomString(200);
            DateTime date = DateTime.UtcNow.Date;

            IEnumerable<TransactionInsertRequest> transactionArrayToInsert = new TransactionInsertRequest[]
            {
                new TransactionInsertRequest
                {
                    Creditor = 1,
                    Debtor = 3,
                    Gross = gross,
                    Reference = reference,
                    Date = date,
                    EnteredBy = 1
                },
                new TransactionInsertRequest
                {
                    Creditor = 1,
                    Debtor = 3,
                    Gross = gross2,
                    Reference = reference,
                    Date = date,
                    EnteredBy = 1
                }
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<IEnumerable<TransactionInsertRequest>>(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod, transactionArrayToInsert);
            IRestResponse<int> response = client.Execute<int>(request);

            string expectedContent = serialize(
                2
            );

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {

            IEnumerable<TransactionInsertRequest> transactionToInsert = new TransactionInsertRequest[]
            {
                new TransactionInsertRequest
                {
                    Creditor = 1,
                    Debtor = 3,
                    Gross = NumberGenerator.RandomDecimal(16, 2),
                    Reference = StringGenerator.RandomString(200),
                    Date = DateTime.Now.Date,
                    EnteredBy = 2
                }
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod, transactionToInsert);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            IEnumerable<TransactionInsertRequest> transactionToInsert = new TransactionInsertRequest[]
            {
                new TransactionInsertRequest
                {
                    Creditor = 1,
                    Debtor = 3,
                    Gross = NumberGenerator.RandomDecimal(16, 2),
                    Reference = StringGenerator.RandomString(200),
                    Date = DateTime.Now.Date,
                    EnteredBy = 1
                }
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId), sutHttpMethod, transactionToInsert);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            IEnumerable<TransactionInsertRequest> transactionToInsert = new TransactionInsertRequest[]
            {
                new TransactionInsertRequest
                {
                    Creditor = 1,
                    Debtor = 3,
                    Gross = NumberGenerator.RandomDecimal(16, 2),
                    Reference = StringGenerator.RandomString(200),
                    Date = DateTime.Now.Date,
                    EnteredBy = 1
                }
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod, transactionToInsert);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }
    }
}

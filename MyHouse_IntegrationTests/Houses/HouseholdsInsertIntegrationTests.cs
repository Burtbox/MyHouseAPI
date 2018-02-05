using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsInsertIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => "Households/";
        public Method sutHttpMethod => Method.POST;

        public HouseholdsInsertIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void InsertHouseholdTest()
        {
            string HouseholdName = StringGenerator.RandomString(50);
            HouseholdInsertRequest householdToInsert = new HouseholdInsertRequest
            {
                Name = HouseholdName,
                EnteredBy = firebaseFixture.H2UserId,
                CreatorDisplayName = firebaseFixture.H2DisplayName
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdInsertRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, householdToInsert);
            IRestResponse<HouseholdResponse> response = client.Execute<HouseholdResponse>(request);

            string expectedContent = serialize(new HouseholdResponse
            {
                HouseholdId = response.Data.HouseholdId, //Setting the expected id to match the response as this is an identity column
                Name = HouseholdName
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Data.HouseholdId.Should().BePositive();
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }


        public void InvalidHouseholdIdTest()
        {
            // NA
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            HouseholdInsertRequest householdToInsert = new HouseholdInsertRequest
            {
                Name = StringGenerator.RandomString(50),
                EnteredBy = firebaseFixture.H1UserId,
                CreatorDisplayName = firebaseFixture.H1DisplayName
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, householdToInsert);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            HouseholdInsertRequest householdToInsert = new HouseholdInsertRequest
            {
                Name = StringGenerator.RandomString(50),
                EnteredBy = firebaseFixture.H2UserId,
                CreatorDisplayName = firebaseFixture.H2DisplayName
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, householdToInsert);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }
    }
}

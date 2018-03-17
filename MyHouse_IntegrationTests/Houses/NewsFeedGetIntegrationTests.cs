using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class NewsFeedsGetIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.NewsFeeds;
        public Method sutHttpMethod => Method.GET;

        public NewsFeedsGetIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void GetNewsFeedsOfHouseholdTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            string expectedContent = serialize(new NewsFeedResponse[]
            {
                new NewsFeedResponse
                {
                    NewsFeedId = 1,
                    HouseholdId = 1,
                    Headline = "Eds Test Headline",
                    SubHeadline = "Eds Test SubHeadline",
                    Story = "Eds Test Story, this can be long",
                    Author = "Ed"
                },
                new NewsFeedResponse
                {
                    NewsFeedId = 3,
                    HouseholdId = 1,
                    Headline = "Eds Test Headline 3",
                    SubHeadline = "Eds Test SubHeadline 3",
                    Story = "Eds Test Story, this can be long 3",
                    Author = "Ed 3"
                }
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            // TODO: Implement!
        }

        public void InvalidHouseholdIdTest()
        {
            // NA
        }

        [Fact]
        public void InvalidUserIdTest()
        {

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat(sutEndpoint, firebaseFixture.H2UserId), sutHttpMethod);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat(sutEndpoint, firebaseFixture.H1UserId), sutHttpMethod);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

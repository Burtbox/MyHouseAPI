using System.Net;
using FluentAssertions;
using MyHouseAPI.Model.Houses;
using MyHouseIntegrationTests.Shared;
using MyHouseUnitTests.Helpers;
using RestSharp;
using Xunit;
using System.Linq;

namespace MyHouseIntegrationTests.Houses
{
    public class NewsFeedsInsertIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.NewsFeeds;
        public Method sutHttpMethod => Method.POST;

        public NewsFeedsInsertIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void InsertNewsFeedTest()
        {
            string headline = StringGenerator.RandomString(100);
            string subheadline = StringGenerator.RandomString(200);
            string author = StringGenerator.RandomString(100);
            string story = StringGenerator.RandomString(500);
            NewsFeedInsertRequest NewsFeedToInsert = new NewsFeedInsertRequest
            {
                Headline = headline,
                SubHeadline = subheadline,
                Author = author,
                Story = story,
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<NewsFeedInsertRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, NewsFeedToInsert);
            IRestResponse<NewsFeedResponse> response = client.Execute<NewsFeedResponse>(request);

            string expectedContent = serialize(new NewsFeedResponse
            {
                NewsFeedId = response.Data != null ? response.Data.NewsFeedId : 0,
                Headline = headline,
                SubHeadline = subheadline,
                Author = author,
                Story = story,
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Data.NewsFeedId.Should().BePositive();
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            NewsFeedInsertRequest NewsFeedToInsert = new NewsFeedInsertRequest
            {
                Headline = StringGenerator.RandomString(100),
                SubHeadline = StringGenerator.RandomString(200),
                Author = StringGenerator.RandomString(100),
                Story = StringGenerator.RandomString(500),
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, NewsFeedToInsert);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            NewsFeedInsertRequest NewsFeedToInsert = new NewsFeedInsertRequest
            {
                Headline = StringGenerator.RandomString(100),
                SubHeadline = StringGenerator.RandomString(200),
                Author = StringGenerator.RandomString(100),
                Story = StringGenerator.RandomString(500),
                EnteredBy = firebaseFixture.H1UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, NewsFeedToInsert);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            NewsFeedInsertRequest NewsFeedToInsert = new NewsFeedInsertRequest
            {
                Headline = StringGenerator.RandomString(100),
                SubHeadline = StringGenerator.RandomString(200),
                Author = StringGenerator.RandomString(100),
                Story = StringGenerator.RandomString(500),
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, NewsFeedToInsert);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }
    }
}
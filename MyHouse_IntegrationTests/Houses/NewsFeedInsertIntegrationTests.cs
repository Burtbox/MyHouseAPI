using System.Net;
using FluentAssertions;
using MyHouseAPI.Model;
using MyHouseIntegrationTests.Shared;
using MyHouseUnitTests.Helpers;
using RestSharp;
using Xunit;

namespace MyHouseIntegrationTests.Houses
{
    public class NewsFeedInsertIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => EndpointsEnum.NewsFeeds;
        public Method sutHttpMethod => Method.POST;

        public NewsFeedInsertIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void InsertNewsFeedTest()
        {
            string newHeadline = StringGenerator.RandomString(100);
            string newSubHeadline = StringGenerator.RandomString(200);
            string newStory = StringGenerator.RandomString(500);
            string authorDisplayName = StringGenerator.RandomString(100);
            NewsFeedInsertRequest newsFeedToInsert = new NewsFeedInsertRequest
            {
                OccupantId = 2,
                Headline = newHeadline,
                SubHeadline = newSubHeadline,
                Story = newStory,
                Author = authorDisplayName,
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<NewsFeedInsertRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, newsFeedToInsert);
            IRestResponse<NewsFeedResponse> response = client.Execute<NewsFeedResponse>(request);

            string expectedContent = serialize(new NewsFeedResponse
            {
                NewsFeedId = response.Data.NewsFeedId,
                OccupantId = 2,
                Headline = newHeadline,
                SubHeadline = newSubHeadline,
                Story = newStory,
                Author = authorDisplayName,
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Data.NewsFeedId.Should().BePositive();
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantIdTest()
        {
            NewsFeedInsertRequest newsFeedToInsert = new NewsFeedInsertRequest
            {
                OccupantId = 1,
                Headline = StringGenerator.RandomString(100),
                SubHeadline = StringGenerator.RandomString(200),
                Story = StringGenerator.RandomString(500),
                Author = StringGenerator.RandomString(100),
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, newsFeedToInsert);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            NewsFeedInsertRequest newsFeedToInsert = new NewsFeedInsertRequest
            {
                OccupantId = 1,
                Headline = StringGenerator.RandomString(100),
                SubHeadline = StringGenerator.RandomString(200),
                Story = StringGenerator.RandomString(500),
                Author = StringGenerator.RandomString(100),
                EnteredBy = firebaseFixture.H1UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, newsFeedToInsert);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            NewsFeedInsertRequest newsFeedToInsert = new NewsFeedInsertRequest
            {
                OccupantId = 2,
                Headline = StringGenerator.RandomString(100),
                SubHeadline = StringGenerator.RandomString(200),
                Story = StringGenerator.RandomString(500),
                Author = StringGenerator.RandomString(100),
                EnteredBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, newsFeedToInsert);
            IRestResponse response = client.Execute<NewsFeedResponse>(request);

            forbiddenExpectations(response);
        }
    }
}

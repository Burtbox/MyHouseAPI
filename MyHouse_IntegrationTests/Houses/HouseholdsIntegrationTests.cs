using System;
using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsIntegrationTests : BaseIntegrationTest
    {
        [Fact]
        public void Test1()
        {
            RestClient client = GetClient();
            RestRequest apiTestCall = apiCall("Occupants/2", Method.GET);
            IRestResponse response = client.Execute<Household>(apiTestCall);
            string content = response.Content;
            content.ShouldBeEquivalentTo(""); //TODO Need to set up data and set the expected reponse here
        }
    }
}

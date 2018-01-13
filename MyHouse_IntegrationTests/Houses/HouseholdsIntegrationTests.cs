using System;
using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsIntegrationTests : BaseIntegrationTest
    {
        [Fact]
        public void GetOccupantsOfHousehold()
        {
            int householdId = 1;
            RestClient client = GetClient();
            RestRequest apiTestCall = apiCall(string.Concat("Occupants/", householdId), Method.GET);
            IRestResponse response = client.Execute<Household>(apiTestCall);
            string content = response.Content;

            string expectedContent = serialize(new Occupant[]
            {
                new Occupant
                {
                    OccupantId = 1,
                    UserId = "O1userId",
                    DisplayName = "O1DispName",
                    HouseholdId = 1
                },
                new Occupant
                {
                    OccupantId = 2,
                    UserId = "O2userId",
                    DisplayName = "O2DispName",
                    HouseholdId = 1
                }
            });

            content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

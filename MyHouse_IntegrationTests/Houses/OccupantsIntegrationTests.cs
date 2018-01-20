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
    public class OccupantsIntegrationTests : BaseIntegrationTest // Should probably have get token stuff as a global setup once!
    {
        [Fact]
        public void GetOccupantsOfHouseholdTest()
        {
            int householdId = 1;
            RestClient client = GetClient();
            RestRequest request = apiCall(string.Concat("Occupants/", userId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<Occupant>(request);
            string content = response.Content;

            string expectedContent = serialize(new Occupant[]
            {
                new Occupant
                {
                    OccupantId = 1,
                    UserId = userId,
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

        [Fact]
        public void InsertOccupantTest()
        {
            OccupantInsert occupantToInsert = new OccupantInsert
            {
                UserId = "O5userId",
                DisplayName = "O5DispName",
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsert>(string.Concat("Occupants/"), Method.POST, occupantToInsert);
            IRestResponse response = client.Execute<Occupant>(request);
            string content = response.Content;

            string expectedContent = serialize(
                new Occupant
                {
                    OccupantId = 5,
                    UserId = "O5userId",
                    DisplayName = "O5DispName",
                    HouseholdId = 2
                }
            );

            content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

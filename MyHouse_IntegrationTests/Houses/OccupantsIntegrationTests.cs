using System;
using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using MyHouseIntegrationTests.Models;

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

            string expectedContent = serialize(new GetResponse<Occupant[]>
            {
                Value = new Occupant[]
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
                },
                StatusCode = 200,
                Formatters = new string[] { },
                ContentTypes = new string[] { },
                DeclaredType = null
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InsertOccupantTest()
        {
            OccupantInsert occupantToInsert = new OccupantInsert
            {
                UserId = "O5userId",
                DisplayName = "O5DispName",
                HouseholdId = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsert>(string.Concat("Occupants/", userId), Method.POST, occupantToInsert);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = serialize(new PostResponse<Occupant>
            {
                Location = "Occupant",
                Value = new Occupant
                {
                    OccupantId = 4,
                    UserId = "O5userId",
                    DisplayName = "O5DispName",
                    HouseholdId = 1
                },
                StatusCode = 201,
                Formatters = new string[] { },
                ContentTypes = new string[] { },
                DeclaredType = null
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

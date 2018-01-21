using System;
using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using MyHouseUnitTests.Helpers;

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
                    UserId = "zzrmi1i7nsApSvmeqA9QSIx1zwfs",
                    DisplayName = "O2DispName",
                    HouseholdId = 1
                }
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InsertOccupantTest()
        {
            string newUserId = StringGenerator.RandomString(28);
            string O4DisplayName = StringGenerator.RandomString(100);
            OccupantInsert occupantToInsert = new OccupantInsert
            {
                UserId = newUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 1
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsert>(string.Concat("Occupants/", userId), Method.POST, occupantToInsert);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = serialize(new Occupant
            {
                OccupantId = 4,
                UserId = newUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 1
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

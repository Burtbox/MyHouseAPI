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
using MyHouseIntegrationTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class OccupantsIntegrationTests : BaseIntegrationTest // Should probably have get token stuff as a global setup once!
    {
        private FirebaseFixture firebaseFixture;
        public OccupantsIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { 
            this.firebaseFixture = firebaseFixture;
        }

        [Fact]
        public void GetOccupantsOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Occupants/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = serialize(new Occupant[]
            {
                new Occupant
                {
                    OccupantId = 1,
                    UserId = firebaseFixture.H1UserId,
                    DisplayName = "Household 1 owner dickbutt",
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
        //TODO: Add cross household test that should 403 and notlogged in test that should 403

        [Fact]
        public void InsertOccupantTest()
        {
            string newUserId = StringGenerator.RandomString(28);
            string O4DisplayName = StringGenerator.RandomString(100);
            OccupantInsert occupantToInsert = new OccupantInsert
            {
                UserId = newUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsert>(firebaseFixture.H2Token, string.Concat("Occupants/", firebaseFixture.H2UserId), Method.POST, occupantToInsert);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = serialize(new Occupant
            {
                OccupantId = 4,
                UserId = newUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

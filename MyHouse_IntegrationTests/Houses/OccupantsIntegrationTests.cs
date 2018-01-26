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
    public class OccupantsIntegrationTests : BaseIntegrationTest
    {
        private FirebaseFixture firebaseFixture;
        public OccupantsIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture)
        {
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

        [Fact]
        public void UpdateOccupantTest()
        {
            string currentUserId = "INPZD3OF1O47G19BUL1LwYAEx6JU";
            string O4DisplayName = StringGenerator.RandomString(100);
            Occupant occupantToUpdate = new Occupant
            {
                OccupantId = 5,
                UserId = currentUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<OccupantInsert>(firebaseFixture.H2Token, string.Concat("Occupants/", firebaseFixture.H2UserId), Method.PUT, occupantToUpdate);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = serialize(new Occupant
            {
                OccupantId = 5,
                UserId = currentUserId,
                DisplayName = O4DisplayName,
                HouseholdId = 2
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidOccupantOfHouseholdTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Occupants/", firebaseFixture.H2UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = "";
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdIdTest()
        {
            int householdId = 2;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H1Token, string.Concat("Occupants/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = "";
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            int householdId = 1;

            RestClient client = GetClient();
            RestRequest request = apiCall(firebaseFixture.H2Token, string.Concat("Occupants/", firebaseFixture.H1UserId, ",", householdId), Method.GET);
            IRestResponse response = client.Execute<Occupant>(request);

            string expectedContent = "";
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Forbidden);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }
    }
}

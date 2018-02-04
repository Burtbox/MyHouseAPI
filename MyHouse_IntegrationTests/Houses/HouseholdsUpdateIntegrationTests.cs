﻿using Xunit;
using FluentAssertions;
using MyHouseIntegrationTests.Shared;
using RestSharp;
using MyHouseAPI.Model;
using System.Net;
using MyHouseUnitTests.Helpers;

namespace MyHouseIntegrationTests.Houses
{
    public class HouseholdsUpdateIntegrationTests : BaseIntegrationTest, IIntegrationTest
    {
        public string sutEndpoint => "Households/";
        public Method sutHttpMethod => Method.PUT;

        public HouseholdsUpdateIntegrationTests(FirebaseFixture firebaseFixture) : base(firebaseFixture) { }

        [Fact]
        public void UpdateHouseholdTest()
        {
            string H5HouseholdName = StringGenerator.RandomString(50);
            HouseholdUpdateRequest householdToUpdate = new HouseholdUpdateRequest
            {
                HouseholdId = 4,
                Name = H5HouseholdName,
                ModifiedBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdUpdateRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, householdToUpdate);
            IRestResponse response = client.Execute<HouseholdResponse>(request);

            string expectedContent = serialize(new HouseholdResponse
            {
                HouseholdId = 4,
                Name = H5HouseholdName,
            });

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ShouldBeEquivalentTo(expectedContent);
        }

        [Fact]
        public void InvalidHouseholdIdTest()
        {

            HouseholdUpdateRequest householdToUpdate = new HouseholdUpdateRequest
            {
                HouseholdId = 4,
                Name = StringGenerator.RandomString(50),
                ModifiedBy = firebaseFixture.H1UserId
            };
            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdUpdateRequest>(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, householdToUpdate);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidUserIdTest()
        {
            HouseholdUpdateRequest householdToUpdate = new HouseholdUpdateRequest
            {
                HouseholdId = 4,
                Name = StringGenerator.RandomString(50),
                ModifiedBy = firebaseFixture.H1UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdUpdateRequest>(firebaseFixture.H2Token, sutEndpoint, sutHttpMethod, householdToUpdate);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            HouseholdUpdateRequest householdToUpdate = new HouseholdUpdateRequest
            {
                HouseholdId = 4,
                Name = StringGenerator.RandomString(50),
                ModifiedBy = firebaseFixture.H2UserId
            };

            RestClient client = GetClient();
            RestRequest request = apiCall<HouseholdUpdateRequest>(firebaseFixture.H1Token, sutEndpoint, sutHttpMethod, householdToUpdate);
            IRestResponse response = client.Execute(request);

            forbiddenExpectations(response);
        }
    }
}

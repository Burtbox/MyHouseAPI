using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;
using MyHouseIntegrationTests.Helpers;

namespace MyHouseIntegrationTests.Shared
{
    [Collection("Firebase Collection")]
    public abstract class BaseIntegrationTest
    {
        public BaseIntegrationTest(FirebaseFixture firebaseFixture)
        {
            this.firebaseFixture = firebaseFixture;
        }

        private FirebaseFixture firebaseFixture;
        private TestSettings testSettings = TestSettingsHelper.testSettings;

        public string serialize(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string serializedObject = JsonConvert.SerializeObject(obj, settings);

            return serializedObject;
        }

        public RestClient GetClient()
        {
            string baseUrl = testSettings.BaseUrl;
            RestClient client = new RestClient(baseUrl);
            return client;
        }

        public RestRequest apiCall(string token, string endpoint, Method method)
        {
            RestRequest request = new RestRequest(endpoint, method);

            // add HTTP Headers
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Authorization", string.Concat("Bearer ", token));

            return request;
        }

        public RestRequest apiCall<T>(string token, string endpoint, Method method, T body)
        {
            RestRequest request = new RestRequest(endpoint, method);

            // add HTTP Headers
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Authorization", string.Concat("Bearer ", token));
            request.AddJsonBody(body);

            return request;
        }
    }
}

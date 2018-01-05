using System;
using Xunit;
using RestSharp;
using Newtonsoft.Json;
using MyHouseAPI.Model;
using System.IO;

namespace MyHouseIntegrationTests.Shared
{
    public abstract class BaseIntegrationTest
    {
        public RestRequest apiCall()
        {
            string baseUrl = JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(@"..//..//..//testsettings.json")).ConnectionString;

            var client = new RestClient(baseUrl);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("Households/1", Method.GET);

            // add HTTP Headers
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");

            // easy async support
            RestRequestAsyncHandle sentRequest = client.ExecuteAsync<Household>(request, response =>
            {
                Console.WriteLine(response.Content);
            });

            return request;
        }
    }
}

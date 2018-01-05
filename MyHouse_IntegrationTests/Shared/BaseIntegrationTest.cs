using System;
using Xunit;
using RestSharp;
using Newtonsoft.Json;
using MyHouseAPI.Model;
using System.IO;
using System.Threading.Tasks;

namespace MyHouseIntegrationTests.Shared
{
    public abstract class BaseIntegrationTest
    {
        public RestRequest apiCall()
        {
            string baseUrl = JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(@"..//..//..//testsettings.json")).BaseUrl;

            var client = new RestClient(baseUrl);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("Occupants/2", Method.GET);

            // add HTTP Headers
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            //TODO Actually generate valid auth token here with request to firebase 
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjhmOWI0YzJhZDNjNDU0NjRjMDhlN2Y4N2M0ODY1MzlmZTkzZDI5YjkifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vbXlob3VzZS1hMDFjNyIsIm5hbWUiOiJEaWNrQnV0dCIsImF1ZCI6Im15aG91c2UtYTAxYzciLCJhdXRoX3RpbWUiOjE1MTUxNzg5OTEsInVzZXJfaWQiOiI3MGFqeFdtclM2WElVNTNHTDZiajFWY2pDc20xIiwic3ViIjoiNzBhanhXbXJTNlhJVTUzR0w2YmoxVmNqQ3NtMSIsImlhdCI6MTUxNTE3ODk5MSwiZXhwIjoxNTE1MTgyNTkxLCJlbWFpbCI6ImRpY2tidXR0QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiZmlyZWJhc2UiOnsiaWRlbnRpdGllcyI6eyJlbWFpbCI6WyJkaWNrYnV0dEBnbWFpbC5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJwYXNzd29yZCJ9fQ.neNDupz2YcGRlbA-ho0kDT4pi6hDsB48V4ioI8KimO_eHADBHmbbxFQgKBD2-C7wXMdK3tzeXyDY7EwAeQPrdpXICBlyIz2iBVfdmtp1r0ExS-xCxI3aFlvwEKcLOaaXt7HQvi3lc2Uqv3gCwOAjz-SoZiV3yFeNhUuYxJbLCegjEAC_nv5To8MKL4sC5dZ6NbK605iHDY7dFIcevS6iCZzkkxIozplWK8mCt3OzQVdx4zLRDHvdiM097Y6xwSyr-liSRLgswqUTwUWwIQmZa5cnwiTpIAkI-7svbmQ-zld_bgcyvI7Qip8NU_3GUgCSCKxE9RqiY6gaUunJzWCqgw");

            // async support
            RestRequestAsyncHandle sentRequest = client.ExecuteAsync<Household>(request, response =>
            {
                Console.WriteLine(response.Content);
            });

            return request;
        }
    }
}

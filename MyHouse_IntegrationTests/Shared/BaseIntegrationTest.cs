using System;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Serialization;

namespace MyHouseIntegrationTests.Shared
{
    public abstract class BaseIntegrationTest
    {
        private TestSettings testSettings = JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(@"..//..//..//testsettings.json"));

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
        public RestRequest apiCall(string endpoint, Method method)
        {
            string token = generateToken();
            RestRequest request = new RestRequest(endpoint, method);

            // add HTTP Headers
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Authorization", string.Concat("Bearer ", token));

            return request;
        }

        public RestRequest apiCall<T>(string endpoint, Method method, T body)
        {
            string token = generateToken();
            RestRequest request = new RestRequest(endpoint, method);

            // add HTTP Headers
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Authorization", string.Concat("Bearer ", token));
            request.AddJsonBody(body);

            return request;
        }
        private string generateToken()
        {
            string customToken = getCustomToken();
            //using an undocumented endpoint to turn our custom token into a live user token
            RestClient client = new RestClient("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyCustomToken?key=AIzaSyA27cRAIaX6NqiLQ4_AHNB91MlHajiTplA");
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(
                new
                {
                    token = customToken,
                    returnSecureToken = true
                }
            );

            IRestResponse response;
            string token = string.Empty;
            try
            {
                response = client.Execute(request);
                token = JsonConvert.DeserializeObject<FirebaseToken>(response.Content).idToken;
            }
            catch (Exception exception)
            {
                throw exception;
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new Exception(response.Content);
            }

            return token;
        }

        private string getCustomToken()
        {
            // get the node js index file
            DirectoryInfo apiDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            string firebaseAdminConsole = String.Concat(apiDirectory.FullName, "\\MyHouse_FirebaseAdmin\\build\\index.js");
            string commandName = "generateCustomToken";
            string args = string.Concat(firebaseAdminConsole, " ", commandName, " ", testSettings.UserId);

            //Run the command
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    FileName = testSettings.NodeJsExe,
                    Arguments = args
                }
            };

            process.Start();
            string customToken = process.StandardOutput.ReadToEnd();

            return customToken;
        }
    }
}

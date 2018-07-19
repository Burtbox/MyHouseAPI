using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using MyHouseAPI.Repositories.Authorization;
using MyHouseIntegrationTests.Shared;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MyHouseIntegrationTests.Helpers
{
    public class TokenHelper
    {
        // private readonly INodeServices nodeServices;
        // private readonly ILogger logger;
        // public TokenHelper(INodeServices nodeServices, ILogger logger)
        // {
        //     this.nodeServices = nodeServices;
        //     this.logger = logger;
        // }
        public async Task<string> GenerateTokenAsync(string userId)
        {
            string customToken = GetCustomToken(userId);
            //using an undocumented endpoint to turn our custom token into a live user token
            RestClient client = new RestClient("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyCustomToken?key=AIzaSyA27cRAIaX6NqiLQ4_AHNB91MlHajiTplA");
            RestRequest request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
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

        // private async Task<string> GetCustomTokenAsync(string userId)
        // {
        //     FirebaseRepository firebaseRepository = new FirebaseRepository(nodeServices, logger);
        //     string customToken = await firebaseRepository.GenerateCustomToken(userId);

        //     return customToken;
        // }

        private string GetCustomToken(string userId)
        {
            // get the node js index file
            // Couldn't get DI Working! 
            DirectoryInfo apiDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            string firebaseAdminConsole = String.Concat(apiDirectory.FullName, "\\MyHouse_FirebaseAdmin\\build\\index.js");
            string commandName = "generateCustomToken";
            string args = string.Concat(firebaseAdminConsole, " ", commandName, " ", userId);

            //Run the command
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    FileName = TestSettingsHelper.TestSettings.NodeJsExe,
                    Arguments = args
                }
            };

            process.Start();
            string customToken = process.StandardOutput.ReadToEnd();

            return customToken;
        }
    }
}

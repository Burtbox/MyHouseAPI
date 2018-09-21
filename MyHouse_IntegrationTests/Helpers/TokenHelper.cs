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

        private string GetCustomToken(string userId)
        {
            string customToken = string.Empty;
            try
            {
                // get the node js index file
                TestSettings settings = TestSettingsHelper.TestSettings;
                DirectoryInfo apiDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
                string firebaseAdminConsole = String.Concat(apiDirectory.FullName, settings.FirebaseAdminConsolePath);
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
                customToken = process.StandardOutput.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
                // TODO: handle errors and surface them - should also use this in main API! 
                // see https://stackoverflow.com/questions/39292421/error-handling-using-process-c-sharp 
            }

            if (customToken == "")
            {
                throw new Exception("Custom token failed to generate");
            }
            return customToken;
        }
    }
}

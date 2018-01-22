using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using MyHouseIntegrationTests.Shared;
using Newtonsoft.Json;
using RestSharp;

namespace MyHouseIntegrationTests.Helpers {
    public static class TokenHelper {
        public static string generateToken(string nodeJsExe, string userId)
        {
            string customToken = getCustomToken(nodeJsExe, userId);
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

        private static string getCustomToken(string nodeJsExe, string userId)
        {
            // get the node js index file
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
                    FileName = nodeJsExe,
                    Arguments = args
                }
            };

            process.Start();
            string customToken = process.StandardOutput.ReadToEnd();

            return customToken;
        }
    }
}

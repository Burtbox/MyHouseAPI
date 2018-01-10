using System;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MyHouseIntegrationTests.Shared
{
    public abstract class BaseIntegrationTest
    {
        private TestSettings testSettings = JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(@"..//..//..//testsettings.json"));

        public RestClient GetClient()
        {
            string baseUrl = testSettings.BaseUrl;
            RestClient client = new RestClient(baseUrl);
            return client;
        }
        public RestRequest apiCall(string endpoint, Method method)
        {
            string token = cheekySneakyToken();
            RestRequest request = new RestRequest(endpoint, method);

            // add HTTP Headers
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Authorization", string.Concat("Bearer ", token));

            return request;
        }

        private string generateToken()
        {
            //TODO - can't get valid token yet!!
            TestSettings firebaseInf = testSettings;

            // NOTE: Replace this with your actual RSA public/private keypair!
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048);
            RSAParameters parameters = provider.ExportParameters(true);

            // Build the credentials used to sign the JWT
            RsaSecurityKey signingKey = new RsaSecurityKey(parameters);
            SigningCredentials signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.RsaSha256);

            // Create a collection of optional claims
            DateTimeOffset now = DateTimeOffset.UtcNow;
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, firebaseInf.Client_Email),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim("uid", "70ajxWmrS6XIU53GL6bj1VcjCsm1", ClaimValueTypes.String)
            };

            // Create and sign the JWT, and write it to a string
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: firebaseInf.Client_Email,
                audience: "https://identitytoolkit.googleapis.com/google.identity.identitytoolkit.v1.IdentityToolkit",
                claims: claims,
                expires: now.AddMinutes(50).DateTime,
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private string cheekySneakyToken()
        {
            RestClient client = new RestClient("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyCustomToken?key=AIzaSyA27cRAIaX6NqiLQ4_AHNB91MlHajiTplA");
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(
                new
                {
                    token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiI3MGFqeFdtclM2WElVNTNHTDZiajFWY2pDc20xIiwiaWF0IjoxNTE1NjIyNzk4LCJleHAiOjE1MTU2MjYzOTgsImF1ZCI6Imh0dHBzOi8vaWRlbnRpdHl0b29sa2l0Lmdvb2dsZWFwaXMuY29tL2dvb2dsZS5pZGVudGl0eS5pZGVudGl0eXRvb2xraXQudjEuSWRlbnRpdHlUb29sa2l0IiwiaXNzIjoiZmlyZWJhc2UtYWRtaW5zZGstc2lub2tAbXlob3VzZS1hMDFjNy5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsInN1YiI6ImZpcmViYXNlLWFkbWluc2RrLXNpbm9rQG15aG91c2UtYTAxYzcuaWFtLmdzZXJ2aWNlYWNjb3VudC5jb20ifQ.cAUf1QJoS3xSa8DXxsr2EFDc6TMvNG6meZQqBlIl72xOurSnaW8h1amisToVWznhlPrLg8YOgSaRraUGi_4t5XYjaaVIZTCMR7pMBnXXz-6mGwSthK3zMwYdNGDJMyIqYTSkVITv5cmCgMLXcB_D7W9uNX2ixSz8DHgBSwp_UMvvZQDTm8gAxlfaxqoGWhCNuXYSi_X2nF2sTMnOCUdNRSfpiWegv9zAvlz57X0IKbcUHjQ6uzn7HHGlMhsZzMOIzkszYLLlEChUgNpXLRj-RBS-0nJK35Ol8vaheMqgz351HRc-NflmrywWqkoJfGWGqrr_sw5GEuvyNSgB_Z0UOg",
                    returnSecureToken = true
                }
            );
            var reponse = client.Execute(request);

            string token = JsonConvert.DeserializeObject<FirebaseToken>(reponse.Content).idToken;
            return token;

        }
    }

}

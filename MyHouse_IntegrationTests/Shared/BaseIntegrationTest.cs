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
            string token = generateToken();
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
    }

}

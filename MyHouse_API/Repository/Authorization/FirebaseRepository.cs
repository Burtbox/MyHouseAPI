using System.Threading.Tasks;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model.Authorization;
using Serilog;
using Microsoft.AspNetCore.NodeServices;
using MyHouseAPI.Model.Houses;
using System;

namespace MyHouseAPI.Repositories.Authorization
{
    public class FirebaseRepository
    {
        private readonly INodeServices nodeServices;
        private readonly ILogger logger;

        public FirebaseRepository(INodeServices nodeServices, ILogger logger)
        {
            this.nodeServices = nodeServices;
            this.logger = logger;
        }

        public async Task<OccupantInviteResponse> GetFirebaseUserByEmail(OccupantInviteRequest invitee)
        {
            OccupantInviteResponse msg = new OccupantInviteResponse();
            try
            {
                // msg = await nodeServices.InvokeAsync<OccupantInviteResponse>("node_services/myHouseFirebaseAdmin.js", $"getFirebaseUserByEmail \"{invitee.Email}\"");
                msg = await nodeServices.InvokeAsync<OccupantInviteResponse>("build/actions/getFirebaseUserByEmail.js", $"{invitee.Email}");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }

            return msg;
        }

        public async Task<string> GenerateCustomToken(string userId)
        {
            string customToken = string.Empty;
            try
            {
                // msg = await nodeServices.InvokeAsync<OccupantInviteResponse>("node_services/myHouseFirebaseAdmin.js", $"generateCustomToken \"{userId}\"");
                customToken = await nodeServices.InvokeAsync<string>("build/actions/generateCustomToken.js", $"{userId}");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }

            return customToken;
        }
    }
}

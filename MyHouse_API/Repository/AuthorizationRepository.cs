using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model;
using Serilog;

namespace MyHouseAPI.Repositories
{
    public class AuthorizationRepository : BaseRepository
    {
        public AuthorizationRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public AuthorizationResponse IsAuthorized(string userId)
        {
            AuthorizationResponse authorizationResponse = new AuthorizationResponse
            {
                IsAuthorized = true
            };
            return authorizationResponse;
        }

        public async Task<AuthorizationResponse> IsHouseholdAuthorized(string userId, int householdId)
        {
            AuthorizationResponse authorizationResponse = new AuthorizationResponse
            {
                IsAuthorized = await checkHousehold(userId, householdId)
            };
            return authorizationResponse;
        }
    }
}

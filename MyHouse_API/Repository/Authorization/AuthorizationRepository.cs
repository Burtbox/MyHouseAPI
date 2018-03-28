using System.Threading.Tasks;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model.Authorization;
using Serilog;

namespace MyHouseAPI.Repositories.Authorization
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

        public async Task<AuthorizationResponse> IsHouseholdAuthorized(string userId, int occupantId)
        {
            AuthorizationResponse authorizationResponse = new AuthorizationResponse
            {
                IsAuthorized = await checkHousehold(userId, occupantId)
            };
            return authorizationResponse;
        }
    }
}

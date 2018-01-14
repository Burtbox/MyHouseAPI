using Microsoft.AspNetCore.Authorization;

namespace MyHouseAPI.Authorization.Policies
{
    public class OwnUserIdRequirement : IAuthorizationRequirement
    {
        public string UserId { get; private set; }

        public OwnUserIdRequirement(string userId)
        {
            UserId = userId;
        }
    }
}

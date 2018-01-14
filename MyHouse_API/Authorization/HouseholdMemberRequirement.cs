using Microsoft.AspNetCore.Authorization;

namespace MyHouseAPI.Authorization.Policies
{
    public class OwnUserIdRequirement : IAuthorizationRequirement { }
}

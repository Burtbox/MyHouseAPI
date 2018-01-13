using Microsoft.AspNetCore.Authorization;

namespace MyHouseAPI.Authorization.Policies
{
    public class HouseholdMemberRequirement : IAuthorizationRequirement
    {
        public int HouseholdId { get; private set; }

        public HouseholdMemberRequirement(int householdId)
        {
            HouseholdId = householdId;
        }
    }
}

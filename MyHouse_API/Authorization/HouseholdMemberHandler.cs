using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Authorization.Policies;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MyHouseAPI.Repositories;

namespace MyHouseAPI.Authorization.Handlers
{
    public class HouseholdMemberHandler : AuthorizationHandler<HouseholdMemberRequirement>
    {
        private readonly OccupantsRepository occupantsRepository;
        public HouseholdMemberHandler(OccupantsRepository occupantsRepository)
        {
            this.occupantsRepository = occupantsRepository;
        }
        protected async override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HouseholdMemberRequirement requirement
        )
        {
            if (!context.User.HasClaim(c =>
                c.Type == "HouseholdId" &&
                c.Issuer == "https://securetoken.google.com/myhouse-a01c7" //TODO move this into config
            ))
            {
                return;
            }

            if (!context.User.HasClaim(c =>
                c.Type == "OccupantId" &&
                c.Issuer == "https://securetoken.google.com/myhouse-a01c7" //TODO move this into config
            ))
            {
                return;
            }

            int householdId = Convert.ToInt32(
                context.User.FindFirst(c =>
                    c.Type == "HouseholdId" && //TODO add the HouseholdId and OccupantId to the firebase claims!
                    c.Issuer == "https://securetoken.google.com/myhouse-a01c7").Value
            );

            int occupantId = Convert.ToInt32(
                context.User.FindFirst(c =>
                    c.Type == "OccupantId" &&
                    c.Issuer == "https://securetoken.google.com/myhouse-a01c7").Value
            );

            int verifiedHouseholdId = await occupantsRepository.OccupantExists(householdId, occupantId);
            if (verifiedHouseholdId == requirement.HouseholdId)
            {
                context.Succeed(requirement);
            }

            return;
        }
    }
}

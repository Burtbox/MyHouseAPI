using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories.Houses;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Model.Houses;

namespace MyHouseAPI.Controllers
{
    [Route("api/Houses/[controller]/[action]")]
    [ApiVersion("3.0")]
    [Authorize]
    public class HouseholdsController : BaseController
    {
        private readonly HouseholdsRepository householdsRepository;
        public HouseholdsController(
            IAuthorizationService authorizationService,
            HouseholdsRepository householdsRepository
            ) : base(authorizationService)
        {
            this.householdsRepository = householdsRepository;
        }

        [HttpGet()]
        [ActionName("OfUser")]
        public async Task<IActionResult> RequestHouseholdsOfOccupant(
            [FromQuery(Name = "userId")] string userId,
            [FromQuery(Name = "includeInvites")] bool includeInvites = false
        )
        {
            return await RequestHandler<IEnumerable<HouseholdResponse>>(HttpVerbs.Get, userId, async () =>
                await householdsRepository.GetHouseholdsOfOccupant(userId, includeInvites));
        }

        [HttpPost]
        public async Task<IActionResult> RequestInsertHousehold([FromBody] HouseholdInsertRequest household)
        {
            string userId = household.EnteredBy;
            return await RequestHandler<HouseholdResponse>(HttpVerbs.Post, userId, async () =>
                await householdsRepository.InsertHousehold(household));
        }

        [HttpPut]
        public async Task<IActionResult> RequestUpdateHousehold([FromBody] HouseholdUpdateRequest household)
        {
            string userId = household.ModifiedBy;
            return await RequestHandler<HouseholdResponse>(HttpVerbs.Put, userId, async () =>
                await householdsRepository.UpdateHousehold(household));
        }

        //[HttpDelete("{userId},{householdId}")]
        // Removed delete method as don't want users to have to delete households (just to leave them)
        // public async Task<IActionResult> RequestDeleteHousehold(string userId, int householdId)
        // {
        //     return await RequestHandler<int>(HttpVerbs.Delete, userId, async () =>
        //         await householdsRepository.DeleteHousehold(userId, householdId));
        // }
    }
}
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories;
using MyHouseAPI.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyHouseAPI.Controllers
{
    [Route("api/[controller]")]
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

        // GET: api/values
        [HttpGet("{userId}")]
        public async Task<IActionResult> RequestHouseholdsOfOccupant(string userId)
        {
            return await RequestHandler<IEnumerable<Household>>(HttpVerbs.Get, userId, async () =>
                await householdsRepository.GetHouseholdsOfOccupant(userId));
        }

        // POST api/values
        [HttpPost("{userId}")]
        public async Task<IActionResult> RequestInsertHousehold([FromBody] HouseholdInsert household)
        {
            return await RequestHandler<Household>(HttpVerbs.Post, household.EnteredBy, async () =>
                await householdsRepository.InsertHousehold(household));
        }

        // PUT api/values/5
        [HttpPut("{household}")]

        public async Task<IActionResult> RequestUpdateHousehold([FromBody] HouseholdUpdate household)
        {
            return await RequestHandler<Household>(HttpVerbs.Put, household.ModifiedBy, async () =>
                await householdsRepository.UpdateHousehold(household.ModifiedBy, household));
        }

        // DELETE api/values/5
        [HttpDelete("{householdId}")]

        public async Task<IActionResult> RequestDeleteHousehold(string userId, int householdId)
        {
            return await RequestHandler<int>(HttpVerbs.Delete, userId, async () =>
                await householdsRepository.DeleteHousehold(userId, householdId));
        }
    }
}
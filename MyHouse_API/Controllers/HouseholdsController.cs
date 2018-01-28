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
        [HttpPost]
        public async Task<IActionResult> RequestInsertHousehold([FromBody] HouseholdInsert household)
        {
            string userId = household.EnteredBy;
            return await RequestHandler<Household>(HttpVerbs.Post, userId, async () =>
                await householdsRepository.InsertHousehold(household));
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> RequestUpdateHousehold([FromBody] HouseholdUpdate household)
        {
            string userId = household.ModifiedBy;
            return await RequestHandler<Household>(HttpVerbs.Put, userId, async () =>
                await householdsRepository.UpdateHousehold(userId, household));
        }

        // DELETE api/values/5
        [HttpDelete("{userId},{householdId}")]
        public async Task<IActionResult> RequestDeleteHousehold(string userId, int householdId)
        {
            return await RequestHandler<int>(HttpVerbs.Delete, userId, async () =>
                await householdsRepository.DeleteHousehold(userId, householdId));
        }
    }
}
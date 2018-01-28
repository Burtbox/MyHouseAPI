using System.Collections.Generic;
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
    public class OccupantsController : BaseController
    {
        private readonly OccupantsRepository occupantsRepository;

        public OccupantsController(
            IAuthorizationService authorizationService,
            OccupantsRepository occupantsRepository
        ) : base(authorizationService)
        {
            this.occupantsRepository = occupantsRepository;
        }

        // GET: api/values
        [HttpGet("{userId},{householdId}")]
        public async Task<IActionResult> RequestOccupantsOfHousehold(string userId, int householdId)
        {
            return await RequestHandler<IEnumerable<Occupant>>(HttpVerbs.Get, userId, async () =>
                await occupantsRepository.GetOccupantsOfHousehold(userId, householdId));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> RequestOccupantInsert([FromBody] OccupantInsert occupant)
        {
            return await RequestHandler<Occupant>(HttpVerbs.Post, occupant.EnteredBy, async () =>
                await occupantsRepository.InsertOccupant(occupant));
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> RequestUpdateOccupant([FromBody] OccupantUpdate occupant)
        {
            return await RequestHandler<Occupant>(HttpVerbs.Put, occupant.ModifiedBy, async () =>
                await occupantsRepository.UpdateOccupant(occupant));
        }

        // DELETE api/values/5
        [HttpDelete("{userId},{householdId},{occupantId}")]
        public async Task<IActionResult> DeleteOccupant(string userId, int householdId, int occupantId)
        {
            return await RequestHandler<int>(HttpVerbs.Delete, userId, async () =>
                await occupantsRepository.DeleteOccupant(userId, householdId, occupantId));
        }
    }
}
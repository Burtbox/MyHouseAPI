using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories;
using MyHouseAPI.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

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
        [HttpPost("{userId}")]
        public async Task<IActionResult> RequestOccupantInsert(string userId, [FromBody] OccupantInsert occupant)
        {
            return await RequestHandler<Occupant>(HttpVerbs.Post, userId, async () =>
                await occupantsRepository.InsertOccupant(userId, occupant));
        }

        // PUT api/values/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> RequestUpdateOccupant(string userId, [FromBody] Occupant occupant)
        {
            return await RequestHandler<Occupant>(HttpVerbs.Put, userId, async () =>
                await occupantsRepository.UpdateOccupant(userId, occupant));
        }

        // DELETE api/values/5
        [HttpDelete("{occupantId}")]
        [Authorize(Policy = "OwnUserId")] // TODO - should probably secure on being that user here
        public async Task<IActionResult> DeleteOccupant(string occupantId)
        {
            await occupantsRepository.DeleteOccupant(occupantId);
            return NoContent();
        }
    }
}
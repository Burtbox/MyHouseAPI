using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories.Houses;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Model.Houses;

namespace MyHouseAPI.Controllers
{
    [Route("api/Houses/[controller]")]
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
        [HttpGet("{userId},{occupantId}")]
        public async Task<IActionResult> RequestOccupantsOfHousehold(string userId, int occupantId)
        {
            return await RequestHandler<IEnumerable<OccupantResponse>>(HttpVerbs.Get, userId, async () =>
                await occupantsRepository.GetOccupantsOfHousehold(userId, occupantId));
        }

        // TODO: Change to invite occupant!
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> RequestOccupantInsert([FromBody] OccupantInsertRequest occupant)
        {
            return await RequestHandler<OccupantResponse>(HttpVerbs.Post, occupant.EnteredBy, async () =>
                await occupantsRepository.InsertOccupant(occupant));
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> RequestUpdateOccupant([FromBody] OccupantUpdateRequest occupant)
        {
            return await RequestHandler<OccupantResponse>(HttpVerbs.Put, occupant.UserId, async () =>
                await occupantsRepository.UpdateOccupant(occupant));
        }

        // DELETE api/values/5
        //[HttpDelete("{userId},{householdId},{occupantId}")]
        // Removed delete method as don't want users to have to delete occupants (just to leave households)
        // public async Task<IActionResult> DeleteOccupant(string userId, int householdId, int occupantId)
        // {
        //     return await RequestHandler<int>(HttpVerbs.Delete, userId, async () =>
        //         await occupantsRepository.DeleteOccupant(userId, householdId, occupantId));
        // }
    }
}
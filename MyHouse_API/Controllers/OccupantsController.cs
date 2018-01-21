using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories;
using MyHouseAPI.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Http;

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
            return await RequestHandler<IEnumerable<Occupant>>(
                userId, async () => await occupantsRepository.GetOccupantsOfHousehold(userId, householdId)
            );
        }

        // POST api/values
        [HttpPost("{userId}")]
        public async Task<IActionResult> RequestOccupantInsert(string userId, [FromBody] OccupantInsert occupant)
        {
            return await RequestHandler<Occupant>(userId, async () => await occupantsRepository.InsertOccupant(userId, occupant));
            //This should return created! Need to think about request handler for this!
        }

        // PUT api/values/5
        [HttpPut("{occupant}")]
        //[Authorize(Policy = "OwnUserId")] 
        public async Task<IActionResult> UpdateOccupant([FromBody] Occupant occupant)
        {
            IActionResult response;

            AuthorizationResult authorizationResult = await authorizationService
                .AuthorizeAsync(User, occupant.UserId, "OwnUserId"); // secure on being that user here
            if (authorizationResult.Succeeded)
            {
                await occupantsRepository.UpdateOccupant(occupant);
                response = NoContent();
            }
            else
            {
                return new ForbidResult();
            }

            return response;
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
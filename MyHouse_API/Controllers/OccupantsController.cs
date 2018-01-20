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
        public async Task<IActionResult> GetOccupantsOfHousehold(string userId, int householdId)
        {
            IEnumerable<Occupant> occupants = await occupantsRepository.GetOccupantsOfHousehold(userId, householdId);
            return Ok(occupants);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> InsertOccupant([FromBody] OccupantInsert occupant)
        {
            IActionResult response;

            var addedOccupant = await occupantsRepository.InsertOccupant(occupant);
            response = Ok(addedOccupant);

            return response;
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
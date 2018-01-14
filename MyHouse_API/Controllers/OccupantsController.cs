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
    public class OccupantsController : Controller
    {
        private readonly OccupantsRepository occupantsRepository;
        private readonly IAuthorizationService authorizationService;

        public OccupantsController(
            IAuthorizationService authorizationService,
            OccupantsRepository occupantsRepository
        )
        {
            this.occupantsRepository = occupantsRepository;
            this.authorizationService = authorizationService;
        }

        // GET: api/values
        [HttpGet("{userId},{householdId}")]
        public async Task<IActionResult> Get(string userId, int householdId)
        {
            try
            {
                AuthorizationResult authorizationResult = await authorizationService
                    .AuthorizeAsync(User, userId, "OwnUserId"); // secure on being that user here
                if (authorizationResult.Succeeded)
                {
                    return Ok(await occupantsRepository.GetAll(userId, householdId));
                }
                else
                {
                    return new ForbidResult();
                }
            }
            catch (InvalidOccupantException exception)
            {
                return Forbid();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured.");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OccupantInsert occupant)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                var addedOccupant = await occupantsRepository.Insert(occupant);
                response = Ok(addedOccupant);
            }
            else
            {
                response = BadRequest(ModelState);
            }

            return response;
        }

        // PUT api/values/5
        [HttpPut("{occupant}")]
        //[Authorize(Policy = "OwnUserId")] 
        public async Task<IActionResult> Put([FromBody] Occupant occupant)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                AuthorizationResult authorizationResult = await authorizationService
                    .AuthorizeAsync(User, occupant.UserId, "OwnUserId"); // secure on being that user here
                if (authorizationResult.Succeeded)
                {
                    await occupantsRepository.Update(occupant);
                    response = NoContent();
                }
                else
                {
                    return new ForbidResult();
                }
            }
            else
            {
                response = BadRequest(ModelState);
            }

            return response;
        }

        // DELETE api/values/5
        [HttpDelete("{occupantId}")]
        [Authorize(Policy = "OwnUserId")] // TODO - should probably secure on being that user here
        public async Task<IActionResult> Delete(string occupantId)
        {
            await occupantsRepository.Delete(occupantId);
            return NoContent();
        }
    }
}
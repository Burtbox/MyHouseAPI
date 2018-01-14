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
    public class OccupantsController : Controller
    {
        private readonly OccupantsRepository occupantsRepository;
        public OccupantsController(OccupantsRepository occupantsRepository)
        {
            this.occupantsRepository = occupantsRepository;
        }

        // GET: api/values
        [HttpGet("{householdId}")]
        [Authorize(Policy = "OwnUserId")]
        public async Task<IEnumerable<Occupant>> Get(int householdId)
        {
            return await occupantsRepository.GetAll(householdId);
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
        [Authorize(Policy = "OwnUserId")] // TODO - should probably secure on being that user here
        public async Task<IActionResult> Put([FromBody] Occupant occupant)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                await occupantsRepository.Update(occupant);
                response = NoContent();
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
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
    public class HouseholdsController : Controller
    {
        private readonly HouseholdsRepository householdsRepository;
        public HouseholdsController(HouseholdsRepository householdsRepository)
        {
            this.householdsRepository = householdsRepository;
        }

        // GET: api/values
        [HttpGet("{userId}")]

        public async Task<IEnumerable<Household>> Get(string userId)
        {
            return await householdsRepository.GetAll(userId);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HouseholdInsert household)
        {
            IEnumerable<Household> addedHousehold = await householdsRepository.Insert(household);
            IActionResult response = Ok(addedHousehold);

            return response;
        }

        // PUT api/values/5
        [HttpPut("{household}")]

        public async Task<IActionResult> Put([FromBody] HouseholdUpdate household)
        {
            await householdsRepository.Update(household);
            IActionResult response = NoContent();

            return response;
        }

        // DELETE api/values/5
        [HttpDelete("{householdId}")]

        public async Task<IActionResult> Delete(string householdId)
        {
            await householdsRepository.Delete(householdId);
            return NoContent();
        }
    }
}
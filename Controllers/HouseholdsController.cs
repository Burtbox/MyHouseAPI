using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using HouseMoneyAPI.Repositories;
using HouseMoneyAPI.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HouseMoneyAPI.Controllers
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
        [HttpGet("{householdId}")]
        public async Task<IEnumerable<Household>> Get(int householdId)
        {
            return await householdsRepository.GetAll(householdId);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HouseholdInsert household)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                var addedHousehold = await householdsRepository.Insert(household);
                response = Ok(addedHousehold);
            }
            else
            {
                response = BadRequest(ModelState);
            }

            return response;
        }

        // PUT api/values/5
        [HttpPut("{household}")]
        public async Task<IActionResult> Put([FromBody] HouseholdUpdate household)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                await householdsRepository.Update(household);
                response = NoContent();
            }
            else
            {
                response = BadRequest(ModelState);
            }

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
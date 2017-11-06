﻿using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using HouseMoneyAPI.Repositories;
using HouseMoneyAPI.Model;
using System.Threading.Tasks;

namespace HouseMoneyAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiVersion("1.0")]
    public class OccupantController : Controller
    {
        private readonly OccupantsRepository occupantsRepository;
        public OccupantController(OccupantsRepository occupantsRepository)
        {
            this.occupantsRepository = occupantsRepository;
        }

        // GET: api/values
        [HttpGet("{householdId}")]
        public async Task<IEnumerable<Occupant>> Get(int householdId)
        {
            return await occupantsRepository.GetAll(householdId);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Occupant occupant)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                await occupantsRepository.Insert(occupant);
                response = NoContent(); //ED! Should probably ret occupantId here!
            }
            else
            {
                response = BadRequest(ModelState);
            }

            return response;
        }

        // PUT api/values/5
        [HttpPut("{occupant}")]
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
        public async Task<IActionResult> Delete(string occupantId)
        {
            await occupantsRepository.Delete(occupantId);
            return NoContent();
        }
    }
}
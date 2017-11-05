using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using HouseMoneyAPI.Repositories;
using HouseMoneyAPI.Model;
using System.Threading.Tasks;

namespace HouseMoneyAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiVersion("1.0")]
    public class UserController : Controller
    {
        private readonly UsersRepository usersRepository;
        public UserController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        // GET: api/values
        [HttpGet("{householdId}")]
        public async Task<IEnumerable<User>> Get(int householdId)
        {
            return await usersRepository.GetAll(householdId);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await usersRepository.Add(user);
            }
        }

        // PUT api/values/5
        [HttpPut("{user}")]
        public async Task Put([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await usersRepository.Update(user);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{userId}")]
        public async Task Delete(string userId)
        {
            await usersRepository.Delete(userId);
        }
    }
}
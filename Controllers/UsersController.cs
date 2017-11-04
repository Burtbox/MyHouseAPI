using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using HouseMoneyAPI.Repositories;
using HouseMoneyAPI.Model;

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
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return usersRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return usersRepository.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            if (ModelState.IsValid)
                usersRepository.Add(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            user.UserId = id;
            if (ModelState.IsValid)
                usersRepository.Update(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usersRepository.Delete(id);
        }
    }
}
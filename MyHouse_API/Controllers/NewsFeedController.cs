using System.Collections.Generic;
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
    public class NewsFeedsController : BaseController
    {
        private readonly NewsFeedsRepository occupantsRepository;

        public NewsFeedsController(
            IAuthorizationService authorizationService,
            NewsFeedsRepository occupantsRepository
        ) : base(authorizationService)
        {
            this.occupantsRepository = occupantsRepository;
        }

        // GET: api/values
        [HttpGet("{userId},{householdId}")]
        public async Task<IActionResult> RequestNewsFeed(string userId, int householdId)
        {
            return await RequestHandler<IEnumerable<NewsFeedResponse>>(HttpVerbs.Get, userId, async () =>
                await occupantsRepository.GetNewsFeeds(userId, householdId));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> RequestNewsFeedInsert([FromBody] NewsFeedInsertRequest occupant)
        {
            return await RequestHandler<NewsFeedResponse>(HttpVerbs.Post, occupant.EnteredBy, async () =>
                await occupantsRepository.InsertNewsFeed(occupant));
        }
    }
}
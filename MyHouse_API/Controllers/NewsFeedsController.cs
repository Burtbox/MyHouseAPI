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
        private readonly NewsFeedsRepository newsFeedsRepository;

        public NewsFeedsController(
            IAuthorizationService authorizationService,
            NewsFeedsRepository newsFeedsRepository
        ) : base(authorizationService)
        {
            this.newsFeedsRepository = newsFeedsRepository;
        }

        // GET: api/values
        [HttpGet("{userId}")]
        public async Task<IActionResult> RequestNewsFeed(string userId)
        {
            return await RequestHandler<IEnumerable<NewsFeedResponse>>(HttpVerbs.Get, userId, async () =>
                await newsFeedsRepository.GetNewsFeeds());
        }
    }
}
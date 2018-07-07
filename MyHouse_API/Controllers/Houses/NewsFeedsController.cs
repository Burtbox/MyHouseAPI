using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories.Houses;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Model.Houses;

namespace MyHouseAPI.Controllers
{
    [Route("api/Houses/[controller]")]
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

        [HttpGet("{userId}")]
        public async Task<IActionResult> RequestNewsFeed(string userId)
        {
            return await RequestHandler<IEnumerable<NewsFeedResponse>>(HttpVerbs.Get, userId, async () =>
                await newsFeedsRepository.GetNewsFeeds(userId));
        }

        [HttpPost]
        public async Task<IActionResult> RequestNewsFeedInsert([FromBody] NewsFeedInsertRequest newsFeed)
        {
            return await RequestHandler<NewsFeedResponse>(HttpVerbs.Get, newsFeed.EnteredBy, async () =>
                await newsFeedsRepository.InsertNewsFeed(newsFeed));
        }
    }
}
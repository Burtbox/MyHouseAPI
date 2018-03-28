using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories.Money;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Model.Money;

namespace MyHouseAPI.Controllers.Money
{
    [Route("api/Money/[controller]")]
    [ApiVersion("3.0")]
    [Authorize]
    public class BalanceController : BaseController
    {
        private readonly BalanceRepository balanceRepository;

        public BalanceController(
            IAuthorizationService authorizationService,
            BalanceRepository balanceRepository
        ) : base(authorizationService)
        {
            this.balanceRepository = balanceRepository;
        }

        // GET: api/values
        [HttpGet("{userId},{occupantId}")]
        public async Task<IActionResult> RequestBalance(string userId, int occupantId)
        {
            return await RequestHandler<IEnumerable<BalanceResponse>>(HttpVerbs.Get, userId, async () =>
                await balanceRepository.GetBalance(userId, occupantId));
        }
    }
}
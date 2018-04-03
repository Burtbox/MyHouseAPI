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
    public class TransactionsController : BaseController
    {
        private readonly TransactionsRepository transactionsRepository;

        public TransactionsController(
            IAuthorizationService authorizationService,
            TransactionsRepository transactionsRepository
        ) : base(authorizationService)
        {
            this.transactionsRepository = transactionsRepository;
        }

        // Post: api/values
        [HttpPost("{userId}")]
        public async Task<IActionResult> RequestInsertTransaction(string userId, [FromBody]TransactionInsertRequest transaction)
        {
            return await RequestHandler<TransactionResponse>(HttpVerbs.Post, userId, async () =>
                await transactionsRepository.InsertTransaction(userId, transaction));
        }
    }
}
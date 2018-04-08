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

        // Get: api/values
        [HttpGet("{userId},{occupantId},{pageSize},{pageNumber}")]
        public async Task<IActionResult> RequestGetTransactionHistory(string userId, int occupantId, int pageSize, int pageNumber)
        {
            if (pageSize < 1)
            {
                ModelState.AddModelError("Error", "Page Size must be greater than 1");
            }
            if (pageNumber < 1)
            {
                ModelState.AddModelError("Error", "Page Number must be greater than 1");
            }
            if (occupantId < 1)
            {
                ModelState.AddModelError("Error", "Occupant Id must be greater than 1");
            }
            if (userId.Length < 28 || userId.Length > 36)
            {
                ModelState.AddModelError("Error", "Invalid User Id");
            }
            return await RequestHandler<IEnumerable<TransactionHistoryResponse>>(HttpVerbs.Get, userId, async () =>
                await transactionsRepository.GetTransactionHistory(userId, occupantId, pageSize, pageNumber));
        }

        // Post: api/values
        [HttpPost("{userId}")]
        public async Task<IActionResult> RequestInsertTransaction(string userId, [FromBody]IEnumerable<TransactionInsertRequest> transaction)
        {
            return await RequestHandler<int>(HttpVerbs.Post, userId, async () =>
                await transactionsRepository.InsertTransaction(userId, transaction));
        }
    }
}
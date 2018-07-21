using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories.Money;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Model.Money;

namespace MyHouseAPI.Controllers.Money
{
    [Route("api/Money/[controller]/[action]")]
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

        [HttpGet]
        [ActionName("History")]
        public async Task<IActionResult> RequestGetTransactionHistory([FromQuery] string userId, [FromQuery]  int occupantId, [FromQuery]  int pageSize, [FromQuery] int pageNumber)
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

        [HttpGet]
        [ActionName("Summary")]
        public async Task<IActionResult> RequestGetTransactionSummary([FromQuery] string userId, [FromQuery] int occupantId)
        {
            if (occupantId < 1)
            {
                ModelState.AddModelError("Error", "Occupant Id must be greater than 1"); // TODO: Move this to a common file
            }
            if (userId.Length < 28 || userId.Length > 36)
            {
                ModelState.AddModelError("Error", "Invalid User Id");
            }
            return await RequestHandler<IEnumerable<TransactionSummaryResponse>>(HttpVerbs.Get, userId, async () =>
                await transactionsRepository.GetTransactionSummary(userId, occupantId));
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> RequestInsertTransaction([FromQuery] string userId, [FromBody]IEnumerable<TransactionInsertRequest> transaction)
        {
            return await RequestHandler<int>(HttpVerbs.Post, userId, async () =>
                await transactionsRepository.InsertTransaction(userId, transaction));
        }
    }
}
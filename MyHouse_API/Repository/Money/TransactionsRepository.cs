using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model.Money;
using Serilog;
using System.Linq;
using MyHouseAPI.Model;

namespace MyHouseAPI.Repositories.Money
{
    public class TransactionsRepository : BaseRepository
    {
        public TransactionsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public async Task<TransactionResponse> InsertTransaction(string userId, IEnumerable<TransactionInsertRequest> transactionList)
        {
            int enteredBy = transactionList.FirstOrDefault().EnteredBy;

            if (transactionList != transactionList.Where(transaction => transaction.EnteredBy == enteredBy))
            {
                throw new InvalidOccupantException();
            }

            return await asyncConnection(userId, enteredBy, async db =>
            {
                TransactionResponse transactionItems = await db.QueryFirstOrDefaultAsync<TransactionResponse>(
                    sql: "[Money].[Transaction_Insert]",
                    param: transactionList,
                    commandType: CommandType.StoredProcedure
                );
                return transactionItems;
            });
        }
    }
}

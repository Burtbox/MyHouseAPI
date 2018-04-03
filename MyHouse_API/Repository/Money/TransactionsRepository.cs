using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model.Money;
using Serilog;

namespace MyHouseAPI.Repositories.Money
{
    public class TransactionsRepository : BaseRepository
    {
        public TransactionsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public async Task<TransactionResponse> InsertTransaction(string userId, TransactionInsertRequest transaction)
        {
            return await asyncConnection(userId, transaction.EnteredBy, async db =>
            {
                TransactionResponse transactionItems = await db.QueryFirstOrDefaultAsync<TransactionResponse>(
                    sql: "[Money].[Transaction_Insert]",
                    param: transaction,
                    commandType: CommandType.StoredProcedure
                );
                return transactionItems;
            });
        }
    }
}

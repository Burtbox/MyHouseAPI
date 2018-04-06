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

        public async Task<int> InsertTransaction(string userId, IEnumerable<TransactionInsertRequest> transactionList)
        {
            int enteredBy = transactionList.FirstOrDefault().EnteredBy;

            if (transactionList.Count() != transactionList.Where(transaction => transaction.EnteredBy == enteredBy).Count())
            {
                throw new InvalidOccupantException();
            }

            return await asyncConnection(userId, enteredBy, async db =>
            {
                int rowsAffected = await db.ExecuteAsync(
                    sql: "[Money].[Transaction_Insert]",
                    param: transactionList,
                    commandType: CommandType.StoredProcedure
                );
                return rowsAffected;
            });
        }
    }
}

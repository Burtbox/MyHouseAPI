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

        public async Task<IEnumerable<TransactionHistoryResponse>> GetTransactionHistory(string userId, int occupantId)
        {
            return await asyncConnection(userId, occupantId, async db =>
            {
                IEnumerable<TransactionHistoryResponse> transactionHistory = await db.QueryAsync<TransactionHistoryResponse>(
                    sql: "[Money].[Transaction_History_Get]",
                    param: new { OccupantId = occupantId },
                    commandType: CommandType.StoredProcedure
                );
                return transactionHistory;
            });
        }

        public async Task<int> InsertTransaction(string userId, IEnumerable<TransactionInsertRequest> transactionList)
        {
            int enteredBy = transactionList.FirstOrDefault().CreditorOccupantId;

            if (transactionList.Count() != transactionList.Where(transaction => transaction.CreditorOccupantId == enteredBy).Count())
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

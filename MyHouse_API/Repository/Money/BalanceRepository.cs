using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model.Money;
using Serilog;

namespace MyHouseAPI.Repositories.Money
{
    public class BalanceRepository : BaseRepository
    {
        public BalanceRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public async Task<IEnumerable<BalanceResponse>> GetBalance(string userId, int occupantId)
        {
            return await asyncConnection(userId, occupantId, async db =>
            {
                IEnumerable<BalanceResponse> balanceItems = await db.QueryAsync<BalanceResponse>(
                    sql: "[Money].[Balance_Get]",
                    param: new { occupantId },
                    commandType: CommandType.StoredProcedure
                );
                return balanceItems;
            });
        }
    }
}

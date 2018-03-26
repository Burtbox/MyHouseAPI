using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model;
using Serilog;

namespace MyHouseAPI.Repositories
{
    public class NewsFeedsRepository : BaseRepository
    {
        public NewsFeedsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public async Task<IEnumerable<NewsFeedResponse>> GetNewsFeeds()
        {
            return await asyncConnection(async db =>
            {
                IEnumerable<NewsFeedResponse> newsItems = await db.QueryAsync<NewsFeedResponse>(
                    sql: "[Houses].[NewsFeeds_Select]",
                    commandType: CommandType.StoredProcedure
                );
                return newsItems;
            });
        }
    }
}

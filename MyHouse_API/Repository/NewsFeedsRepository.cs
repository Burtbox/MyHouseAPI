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

        public async Task<IEnumerable<NewsFeedResponse>> GetNewsFeeds(string userId)
        {
            return await asyncConnection(async db =>
            {
                IEnumerable<NewsFeedResponse> newsItems = await db.QueryAsync<NewsFeedResponse>(
                    sql: "[Houses].[NewsFeeds_Get]",
                    param: new { UserId = userId },
                    commandType: CommandType.StoredProcedure
                );
                return newsItems;
            });
        }

        public async Task<NewsFeedResponse> InsertNewsFeed(NewsFeedInsertRequest newsItem)
        {
            return await asyncConnection(newsItem.EnteredBy, newsItem.OccupantId, async db =>
            {
                NewsFeedResponse insertedNewsFeed = await db.QueryFirstAsync<NewsFeedResponse>(
                    sql: "[Houses].[NewsFeeds_Insert]",
                    param: newsItem,
                    commandType: CommandType.StoredProcedure
                );
                return insertedNewsFeed;
            });
        }
    }
}

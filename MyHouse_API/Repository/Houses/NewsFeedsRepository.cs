using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model.Houses;
using Serilog;

namespace MyHouseAPI.Repositories.Houses
{
    public class NewsFeedsRepository : BaseRepository
    {
        public NewsFeedsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public async Task<IEnumerable<NewsFeedResponse>> GetNewsFeeds(string userId)
        {
            return await asyncConnection(async db =>
            {
                IEnumerable<NewsFeedResponse> newsItems = await db.QueryAsync<NewsFeedResponse>(
                    sql: "[Houses].[NewsFeeds_Select]",
                    commandType: CommandType.StoredProcedure,
                    param: new { UserId = userId }
                );
                return newsItems;
            });
        }

        public async Task<NewsFeedResponse> InsertNewsFeed(NewsFeedInsertRequest newsFeed)
        {
            return await asyncConnection(newsFeed.EnteredBy, newsFeed.OccupantId, async db =>
            {
                return await InsertNewsFeedQuery(db, newsFeed);
            });
        }

        public async Task<NewsFeedResponse> InsertNewsFeedQuery(IDbConnection db, NewsFeedInsertRequest newsFeed)
        {
            NewsFeedResponse newsFeedItem = await db.QueryFirstOrDefaultAsync<NewsFeedResponse>(
                    sql: "[Houses].[NewsFeeds_Insert]",
                    commandType: CommandType.StoredProcedure,
                    param: newsFeed
                );
            return newsFeedItem;
        }
    }
}

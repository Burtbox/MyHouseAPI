using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model;
using Serilog;

namespace MyHouseAPI.Repositories
{
    public class HouseholdsRepository : BaseRepository
    {
        public HouseholdsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public async Task<IEnumerable<Household>> GetHouseholdsOfOccupant(string userId)
        {
            return await asyncConnection(async db =>
            {
                IEnumerable<Household> usersHouseholds = await db.QueryAsync<Household>(
                    sql: "[Houses].[Households_Of_Occupant]",
                    param: new { UserId = userId },
                    commandType: CommandType.StoredProcedure
                );
                return usersHouseholds;
            });
        }

        public async Task<Household> InsertHousehold(HouseholdInsert household)
        {
            return await asyncConnection(async db =>
            {
                Household insertedHousehold = await db.QueryFirstOrDefaultAsync<Household>(
                    sql: "[Houses].[Households_Insert]",
                    param: household,
                    commandType: CommandType.StoredProcedure
                );
                return insertedHousehold;
            });
        }

        public async Task<Household> UpdateHousehold(string userId, HouseholdUpdate household)
        {
            return await asyncConnection(userId, household.HouseholdId, async db =>
             {
                 Household rowsUpdated = await db.QueryFirstOrDefaultAsync<Household>(
                    sql: "[Houses].[Households_Update]",
                    param: household,
                    commandType: CommandType.StoredProcedure
                 );
                 return rowsUpdated;
             });
        }

        public async Task<int> DeleteHousehold(string userId, int householdId)
        {
            return await asyncConnection(userId, householdId, async db =>
            {
                int rowsDeleted = await db.ExecuteAsync(
                    sql: "[Houses].[Households_Delete]",
                    param: new { HouseholdId = householdId },
                    commandType: CommandType.StoredProcedure
                );
                return rowsDeleted;
            });
        }
    }
}

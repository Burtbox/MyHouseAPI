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

        public async Task<IEnumerable<Household>> GetAll(string userId)
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

        public async Task<IEnumerable<Household>> Insert(HouseholdInsert household)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", household.Name);
            parameters.Add("@EnteredBy", household.EnteredBy);

            return await asyncConnection(async db =>
            {
                IEnumerable<Household> insertedHousehold = await db.QueryAsync<Household>(
                    sql: "[Houses].[Households_Insert]",
                    param: household,
                    commandType: CommandType.StoredProcedure
                );
                return insertedHousehold;
            });
        }

        public async Task<int> Update(HouseholdUpdate household)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@HouseholdId", household.HouseholdId);
            parameters.Add("@Name", household.Name);
            parameters.Add("@ModifiedBy", household.ModifiedBy);

            return await asyncConnection(async db =>
             {
                 int rowsUpdated = await db.ExecuteAsync(
                    sql: "[Houses].[Households_Update]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                 );
                 return rowsUpdated;
             });
        }

        public async Task<IEnumerable<int>> Delete(string householdId)
        {
            return await asyncConnection(async db =>
            {
                IEnumerable<int> rowsDeleted = await db.QueryAsync<int>(
                    sql: "[Houses].[Households_Delete]",
                    param: new { HouseholdId = householdId },
                    commandType: CommandType.StoredProcedure
                );
                return rowsDeleted;
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Helpers;
using MyHouseAPI.Model;
using Serilog;

namespace MyHouseAPI.Repositories
{
    public class HouseholdsRepository : BaseRepository
    {
        public HouseholdsRepository(ConnectionHelper connection, ILogger logger) : base(connection, logger) { }

        public async Task<IEnumerable<Household>> GetAll(string userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<Household>(
                    sql: "[Houses].[Households_Of_Occupant]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
            });
        }

        public async Task<IEnumerable<Household>> Insert(HouseholdInsert household)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", household.Name);
            parameters.Add("@EnteredBy", household.EnteredBy);
            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<Household>(
                    sql: "[Houses].[Households_Insert]",
                    param: household,
                    commandType: CommandType.StoredProcedure
                );
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
                 return await db.ExecuteAsync(
                 sql: "[Houses].[Households_Update]",
                 param: parameters,
                 commandType: CommandType.StoredProcedure
                 );
             });
        }

        public async Task<IEnumerable<int>> Delete(string householdId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@HouseholdId", householdId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<int>(
                    sql: "[Houses].[Households_Delete]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
            });
        }
    }
}

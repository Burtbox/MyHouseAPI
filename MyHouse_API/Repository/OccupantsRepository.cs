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
    public class OccupantsRepository : BaseRepository
    {
        public OccupantsRepository(ConnectionHelper connection, ILogger logger) : base(connection, logger) { }

        public async Task<IEnumerable<Occupant>> GetAll(int householdId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@HouseholdId", householdId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<Occupant>(
                    sql: "[Houses].[Occupants_Of_Household]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
            });
        }

        public async Task<Occupant> Insert(OccupantInsert occupant)
        {
            return await asyncConnection(async db =>
            {
                return await db.QueryFirstAsync<Occupant>(
                    sql: "[Houses].[Occupants_Insert]",
                    param: occupant,
                    commandType: CommandType.StoredProcedure
                );
            });
        }

        public async Task<int> Update(Occupant occupant)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", occupant.UserId);
            parameters.Add("@DisplayName", occupant.DisplayName);

            return await asyncConnection(async db =>
             {
                 return await db.ExecuteAsync(
                 sql: "[Houses].[Occupants_Update]",
                 param: parameters,
                 commandType: CommandType.StoredProcedure
                 );
             });
        }

        public async Task<int> Delete(string occupantId)
        {
            return await asyncConnection(async db =>
            {
                return await db.QueryFirstAsync<int>(
                    sql: "[Houses].[Occupants_Delete]",
                    param: new { OccupantId = occupantId } ,
                    commandType: CommandType.StoredProcedure
                );
            });
        }

        public async Task<int> OccupantExists(int householdId, int occupantId)
        {
            return await asyncConnection(async db =>
            {
                return await db.QueryFirstAsync<int>(
                    sql: "[Houses].[Occupant_Exists]",
                    param: new { HouseholdId = householdId, OccupantId = occupantId },
                    commandType: CommandType.StoredProcedure
                );
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model;
using Serilog;

namespace MyHouseAPI.Repositories
{
    public class OccupantsRepository : BaseRepository
    {
        public OccupantsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

        public async Task<IEnumerable<Occupant>> GetOccupantsOfHousehold(string userId, int householdId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@HouseholdId", householdId);

            return await asyncConnection(userId, householdId, async db =>
            {
                IEnumerable<Occupant> occupants = await db.QueryAsync<Occupant>(
                    sql: "[Houses].[Occupants_Of_Household]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return occupants;
            });
        }

        public async Task<Occupant> InsertOccupant(string userId, OccupantInsert occupant)
        {
            return await asyncConnection(userId, occupant.HouseholdId, async db =>
            {
                Occupant insertedOccupant = await db.QueryFirstAsync<Occupant>(
                    sql: "[Houses].[Occupants_Insert]",
                    param: occupant,
                    commandType: CommandType.StoredProcedure
                );
                return insertedOccupant;
            });
        }

        public async Task<int> UpdateOccupant(Occupant occupant)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", occupant.UserId);
            parameters.Add("@DisplayName", occupant.DisplayName);

            return await asyncConnection(async db =>
             {
                 int rowsUpdated = await db.ExecuteAsync(
                    sql: "[Houses].[Occupants_Update]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                 );
                 return rowsUpdated;
             });
        }

        public async Task<int> DeleteOccupant(string occupantId)
        {
            return await asyncConnection(async db =>
            {
                int rowsDeleted = await db.QueryFirstAsync<int>(
                    sql: "[Houses].[Occupants_Delete]",
                    param: new { OccupantId = occupantId },
                    commandType: CommandType.StoredProcedure
                );
                return rowsDeleted;
            });
        }
    }
}

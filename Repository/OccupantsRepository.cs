using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HouseMoneyAPI.Helpers;
using HouseMoneyAPI.Model;

namespace HouseMoneyAPI.Repositories
{
    public class OccupantsRepository : BaseRepository
    {
        public OccupantsRepository(ConnectionHelper connection) : base(connection) { }

        public async Task<IEnumerable<Occupant>> GetAll(int householdId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@householdId", householdId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<Occupant>(
                    sql: "[Houses].[Occupants_Of_Household]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
            });
        }

        public async Task<int> Insert(Occupant occupant)
        {
            return await asyncConnection(async db =>
            {
                return await db.ExecuteAsync(
                    sql: "Houses.Occupants_Insert",
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

        public async Task<IEnumerable<int>> Delete(string occupantId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OccupantId", occupantId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<int>(
                    sql: "[Houses].[Occupants_Delete]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
            });
        }
    }
}

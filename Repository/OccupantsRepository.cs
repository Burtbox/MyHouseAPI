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
            string sqlString = "SELECT * FROM Houses.Occupants WHERE HouseholdId = @householdId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@householdId", householdId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<Occupant>(
                    sql: sqlString,
                    param: parameters,
                    commandType: CommandType.Text
                );
            });
        }

        public async Task<int> Add(Occupant occupant)
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
            return await asyncConnection(async db =>
             {
                 return await db.ExecuteAsync(
                 sql: "UPDATE Houses.Occupants" +
                     " SET DisplayName = @DisplayName" +
                     " WHERE OccupantId = @OccupantId",
                 param: occupant,
                 commandType: CommandType.Text
                 );
             });
        }

        public async Task<IEnumerable<int>> Delete(string occupantId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@occupantId", occupantId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<int>(
                    sql: "DELETE FROM Houses.Occupants WHERE OccupantId = @occupantId",
                    param: parameters,
                    commandType: CommandType.Text
                );
            });
        }
    }
}

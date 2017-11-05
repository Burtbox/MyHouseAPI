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
    public class UsersRepository : Repository
    {
        public UsersRepository(ConnectionHelper connection) : base(connection) { }

        public async Task<IEnumerable<User>> Add(User user)
        {
            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<User>(
                    sql: "Houses.Users_Insert",
                    param: user,
                    commandType: CommandType.StoredProcedure
                );
            });
        }

        public async Task<IEnumerable<User>> GetAll(int householdId)
        {
            string sqlString = "SELECT * FROM Houses.Users WHERE HouseholdId = @householdId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@householdId", householdId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<User>(
                    sql: sqlString,
                    param: parameters,
                    commandType: CommandType.Text
                );
            });
        }

        public async Task<IEnumerable<int>> Delete(string userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);

            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<int>(
                    sql: "DELETE FROM Houses.Users WHERE UserId = @userId",
                    param: parameters,
                    commandType: CommandType.Text
                );
            });
        }

        public async Task<IEnumerable<User>> Update(User user)
        {
            return await asyncConnection(async db =>
             {
                 return await db.QueryAsync<User>(
                 sql: "UPDATE Houses.Users" +
                     " SET DisplayName = @DisplayName" +
                     " WHERE UserId = @UserId",
                 param: user,
                 commandType: CommandType.Text
                 );
             });
        }
    }
}

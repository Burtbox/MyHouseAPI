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

        // public async Task<User> AddUser(User parameters)
        // {
        //     string sqlString = "EXEC Houses.Users_Insert" +
        //             "  @UserId = @UserId" +
        //             ", @DisplayName = @DisplayName" +
        //             ", @HouseholdId = @HouseHoldId";
        //     // return await asyncConnection(async db =>
        //     // {
        //     //     return await db.QueryAsync<User>(
        //     //         sql: sqlString,
        //     //         param: parameters,
        //     //         commandType: CommandType.StoredProcedure
        //     //     );
        //     // });
        // }

        public async Task<IEnumerable<User>> GetAll()
        {
            string sqlString = "SELECT * FROM Houses.Users";
            return await asyncConnection(async db =>
            {
                return await db.QueryAsync<User>(
                    sql: sqlString,
                    commandType: CommandType.Text
                );
            });
        }
        /*
        public User GetById(int id)
        {
            using (dbConnection)
            {
                string sQuery = "SELECT * FROM Houses.Users" +
                    " WHERE UserId = @UserId";

                return dbConnection.Query<User>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (dbConnection)
            {
                string sQuery = "DELETE FROM Houses.Users" +
                    " WHERE UserId = @UserId";

                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(User prod)
        {
            using (dbConnection)
            {
                string sQuery = "UPDATE Houses.Users" +
                    " SET DisplayName = @DisplayName" +
                    " WHERE UserId = @UserId";

                dbConnection.Query(sQuery, prod);
            }
        }
        */
    }
}
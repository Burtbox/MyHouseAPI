using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using HouseMoneyAPI.Helpers;
using HouseMoneyAPI.Model;

namespace HouseMoneyAPI.Repositories
{
    public class UsersRepository
    {
        private readonly ConnectionHelper dbConnection;
        public UsersRepository(ConnectionHelper connection) => this.dbConnection = connection;

        public void Add(User prod)
        {
            dbConnection.Open();
            try
            {
                string sqlString = "EXEC Houses.Users_Insert" +
                    "  @UserId = @UserId" +
                    ", @DisplayName = @DisplayName" +
                    ", @HouseholdId = @HouseHoldId";
                dbConnection.Execute(sql: sqlString, param: prod);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (dbConnection)
            {
                return dbConnection.Query<User>("SELECT * FROM Houses.Users");
            }
        }

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
    }
}
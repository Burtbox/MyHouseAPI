using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace HouseMoneyAPI {
    public class UserRepository {
        private IDbConnection _dbConnection;
        private ConnectionHelper connectionHelper;
        public UserRepository () {
            connectionHelper = new ConnectionHelper ();
        }

        public void Add (User prod) {
            using (IDbConnection dbConnection = connectionHelper.Connection) {
                string sQuery = "EXEC Houses.Users_Insert" +
                    "  @UserId = @UserId" +
                    ", @DisplayName = @DisplayName" +
                    ", @HouseholdId = @HouseHoldId";
                dbConnection.Execute (sQuery, prod);
            }
        }

        public IEnumerable<User> GetAll () {
            using (IDbConnection dbConnection = connectionHelper.Connection) {
                return dbConnection.Query<User> ("SELECT * FROM Houses.Users");
            }
        }

        public User GetById (int id) {
            using (IDbConnection dbConnection = connectionHelper.Connection) {
                string sQuery = "SELECT * FROM Houses.Users" +
                    " WHERE UserId = @UserId";

                return dbConnection.Query<User> (sQuery, new { Id = id }).FirstOrDefault ();
            }
        }

        public void Delete (int id) {
            using (IDbConnection dbConnection = connectionHelper.Connection) {
                string sQuery = "DELETE FROM Houses.Users" +
                    " WHERE UserId = @UserId";

                dbConnection.Execute (sQuery, new { Id = id });
            }
        }

        public void Update (User prod) {
            using (IDbConnection dbConnection = connectionHelper.Connection) {
                string sQuery = "UPDATE Houses.Users" +
                    " SET DisplayName = @DisplayName" +
                    " WHERE UserId = @UserId";

                dbConnection.Query (sQuery, prod);
            }
        }
    }
}
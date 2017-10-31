using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace HouseMoneyAPI {
    public class ConnectionHelper {
        private string connectionString;
        public ConnectionHelper () {

            connectionString = @"Server=EDLAPTOP\EDLAPTOPSQL;Database=MyHouse_Dev;User Id=HMApp;Password=dickbutt11!";
            //connectionString = StartUp.Configuration.GetConnectionString ("DefaultConnection");
        }

        public IDbConnection Connection {
            get {
                return new SqlConnection (connectionString);
            }
        }
    }
}
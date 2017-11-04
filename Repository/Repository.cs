using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using HouseMoneyAPI.Helpers;

namespace HouseMoneyAPI.Repositories
{
    public abstract class Repository
    {
        private readonly ConnectionHelper dbConnection;

        protected Repository(ConnectionHelper connection) => this.dbConnection = connection;

        protected async Task<T> asyncConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (dbConnection)
                {
                    await dbConnection.OpenAsync(); // Asynchronously open a connection to the database
                    return await getData(dbConnection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
                }
            }
            catch (TimeoutException exception)
            {
                throw new Exception(String.Format("{0}.asyncConnection() experienced a SQL timeout", GetType().FullName), exception);
            }
            catch (SqlException exception)
            {
                throw new Exception(String.Format("{0}.asyncConnection() experienced a SQL exception (not a timeout)", GetType().FullName), exception);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using HouseMoneyAPI.Helpers;
using Serilog;

namespace HouseMoneyAPI.Repositories
{
    public abstract class BaseRepository
    {
        private readonly ConnectionHelper dbConnection;
        private readonly ILogger logger;
        private enum ExceptionTypes { Timeout, SQLError, Unknown }

        protected BaseRepository(ConnectionHelper connection, ILogger logger) {
            this.dbConnection = connection;
            this.logger = logger;
        }
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
                this.logger.Error(exception, formattedErrorMessage(ExceptionTypes.Timeout), ExceptionTypes.Timeout.ToString());
                throw new Exception(formattedErrorMessage(ExceptionTypes.Timeout), exception);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception, formattedErrorMessage(ExceptionTypes.SQLError), ExceptionTypes.SQLError.ToString());
                throw new Exception(formattedErrorMessage(ExceptionTypes.SQLError), exception);
            }
            catch (Exception exception)
            {
                this.logger.Error(exception, formattedErrorMessage(ExceptionTypes.Unknown), ExceptionTypes.Unknown.ToString());
                throw new Exception(formattedErrorMessage(ExceptionTypes.Unknown), exception);
            }
        }
        private string formattedErrorMessage(ExceptionTypes origin) {
            Dictionary<ExceptionTypes, string> APICallErrors = new Dictionary<ExceptionTypes, string>();
            APICallErrors.Add(ExceptionTypes.Timeout, "experienced a SQL timeout");
            APICallErrors.Add(ExceptionTypes.SQLError, "experienced a SQL exception");
            APICallErrors.Add(ExceptionTypes.Unknown, "experienced exception (not a timeout or SQL)");

            return String.Format("{0} {1}", GetType().FullName, APICallErrors[origin]);
        }
    }
}

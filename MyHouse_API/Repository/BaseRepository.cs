using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MyHouseAPI.Helpers;
using Serilog;
using Dapper;
using MyHouseAPI.Model;

namespace MyHouseAPI.Repositories
{
    public abstract class BaseRepository
    {
        private readonly ConnectionHelper dbConnection;
        private readonly ILogger logger;
        private enum ExceptionTypes { Timeout, SQLError, Unknown, InvalidOccupant }

        protected BaseRepository(ConnectionHelper connection, ILogger logger)
        {
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
            catch (Exception exception)
            {
                throw customCatch(exception);
            }
        }
        private async Task<bool> validateHouseholdOccupant(IDbConnection db, string userId, int householdId)
        {
            if (
                await db.QueryFirstAsync<int>(
                    sql: "[Houses].[Validate_Household_Occupant]",
                    param: new { UserId = userId, HouseholdId = householdId },
                    commandType: CommandType.StoredProcedure
                ) == 1
            )
            {
                return true;
            }
            else
            {
                throw new InvalidOccupantException();
            }
        }
        protected async Task<T> asyncConnection<T>(string userId, int householdId, Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (dbConnection)
                {
                    await dbConnection.OpenAsync(); // Asynchronously open a connection to the database
                    await validateHouseholdOccupant(dbConnection, userId, householdId); // Validate the occupant lives in that household
                    return await getData(dbConnection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
                }
            }
            catch (Exception exception)
            {
                throw customCatch(exception);
            }
        }
        private Exception customCatch(Exception exception)
        {
            switch (exception.GetType().Name)
            {
                case "TimeoutException":
                    this.logger.Error(exception, formattedErrorMessage(ExceptionTypes.Timeout), exception.Message);
                    return new Exception(formattedErrorMessage(ExceptionTypes.Timeout), exception);
                case "SqlException":
                    this.logger.Error(exception, formattedErrorMessage(ExceptionTypes.SQLError), exception.Message);
                    return new Exception(formattedErrorMessage(ExceptionTypes.SQLError), exception);
                case "InvalidOccupantException":
                    this.logger.Error(exception, formattedErrorMessage(ExceptionTypes.SQLError), exception.Message);
                    return new InvalidOccupantException(formattedErrorMessage(ExceptionTypes.SQLError), exception);
                default:
                    this.logger.Error(exception, formattedErrorMessage(ExceptionTypes.Unknown), exception.Message);
                    return new Exception(formattedErrorMessage(ExceptionTypes.Unknown), exception);
            }
        }
        private string formattedErrorMessage(ExceptionTypes origin)
        {
            Dictionary<ExceptionTypes, string> APICallErrors = new Dictionary<ExceptionTypes, string>();
            APICallErrors.Add(ExceptionTypes.Timeout, "experienced a SQL timeout: Details {0}");
            APICallErrors.Add(ExceptionTypes.SQLError, "experienced a SQL exception: Details {0}");
            APICallErrors.Add(ExceptionTypes.Unknown, "experienced exception (not a timeout or SQL): Details {0}");
            APICallErrors.Add(ExceptionTypes.InvalidOccupant, "experienced exception (Invalid occupant of household): Details {0}");

            return String.Format("{0} {1}", GetType().FullName, APICallErrors[origin]);
        }
    }
}

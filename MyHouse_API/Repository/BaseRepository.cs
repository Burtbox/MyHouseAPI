using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MyHouseAPI.Handlers;
using Serilog;
using Dapper;
using MyHouseAPI.Model;
using System.Data.SqlClient;

namespace MyHouseAPI.Repositories
{
    public abstract class BaseRepository
    {
        private readonly ConnectionHandler dbConnection;
        private readonly ILogger logger;
        private enum ExceptionTypes { Timeout, SQLError, Unknown, InvalidOccupant }

        protected BaseRepository(ConnectionHandler connection, ILogger logger)
        {
            this.dbConnection = connection;
            this.logger = logger;
        }
        /// <summary>
        /// An unrestricted async connection - this should only be used when the user does not need to belong to a household
        /// </summary>
        /// <param name="getData"></param>
        /// <returns></returns>
        protected async Task<T> asyncConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                this.logger.Information("Attempting asyncConnection without userId or OccupantId");
                using (dbConnection)
                {
                    await dbConnection.OpenAsync(); // Asynchronously open a connection to the database
                    this.logger.Information("Established asyncConnection without userId or OccupantId");
                    return await getData(dbConnection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
                }
            }
            catch (Exception exception)
            {
                throw customCatch(exception);
            }
        }

        private async Task<bool> validateHouseholdOccupant(IDbConnection db, string userId, int occupantId)
        {
            if (
                await db.QueryFirstAsync<int>(
                    sql: "[Houses].[Validate_Occupant_In_Household]",
                    param: new { UserId = userId, OccupantId = occupantId },
                    commandType: CommandType.StoredProcedure
                ) == 1
            )
            {
                this.logger.Information($"Valid Occupant with UserId: {userId} and OccupantId: {occupantId}");
                return true;
            }
            else
            {
                this.logger.Warning($"Invalid Occupant with UserId: {userId} and OccupantId: {occupantId}");
                throw new InvalidOccupantException();
            }
        }

        /// <summary>
        /// An async connection that validates the user belongs to the household
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="occupantId"></param>
        /// <param name="getData"></param>
        /// <returns></returns>
        protected async Task<T> asyncConnection<T>(string userId, int occupantId, Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                this.logger.Information($"Attempting asyncConnection with userId {userId} and OccupantId: {occupantId}");
                using (dbConnection)
                {
                    await dbConnection.OpenAsync(); // Asynchronously open a connection to the database
                    await validateHouseholdOccupant(dbConnection, userId, occupantId); // Validate the occupant lives in that household
                    this.logger.Information($"Established asyncConnection with userId {userId} and OccupantId: {occupantId}");
                    return await getData(dbConnection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
                }
            }
            catch (Exception exception)
            {
                throw customCatch(exception);
            }
        }

        /// <summary>
        /// An async connection that validates the user belongs to the household
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="occupantId"></param>
        /// <returns></returns>
        protected async Task<bool> checkHousehold(string userId, int occupantId)
        {
            try
            {
                this.logger.Information($"Running checkHousehold for userId {userId} and OccupantId: {occupantId}");
                using (dbConnection)
                {
                    await dbConnection.OpenAsync(); // Asynchronously open a connection to the database
                    this.logger.Information($"Established checkHousehold connection for userId {userId} and OccupantId: {occupantId}");
                    return await validateHouseholdOccupant(dbConnection, userId, occupantId); // Validate the occupant lives in that household
                }
            }
            catch (Exception exception)
            {
                throw customCatch(exception);
            }
        }

        private Exception customCatch(Exception exception)
        {
            string formattedErrorMessage;
            switch (exception)
            {
                case TimeoutException timeoutException:
                    formattedErrorMessage = formatErrorMessage(ExceptionTypes.Timeout);
                    this.logger.Error(timeoutException, formattedErrorMessage, timeoutException.Message);
                    return new Exception(formattedErrorMessage, timeoutException);
                case SqlException sqlException:
                    formattedErrorMessage = formatErrorMessage(ExceptionTypes.SQLError);
                    this.logger.Error(sqlException, formattedErrorMessage, sqlException.Message);
                    return new Exception(formattedErrorMessage, sqlException);
                case InvalidOccupantException invalidOccupant:
                    formattedErrorMessage = formatErrorMessage(ExceptionTypes.InvalidOccupant);
                    this.logger.Error(invalidOccupant, formattedErrorMessage, invalidOccupant.Message);
                    return new InvalidOccupantException(formattedErrorMessage, invalidOccupant);
                default:
                    formattedErrorMessage = formatErrorMessage(ExceptionTypes.Unknown);
                    this.logger.Error(exception, formattedErrorMessage, exception.Message);
                    return new Exception(formattedErrorMessage, exception);
            }
        }
        private string formatErrorMessage(ExceptionTypes origin)
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

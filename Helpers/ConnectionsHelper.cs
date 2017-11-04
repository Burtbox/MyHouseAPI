using System;
using System.Data;
using System.Data.SqlClient;

namespace HouseMoneyAPI.Helpers
{
    public class ConnectionHelper : IDbConnection
    {
        private SqlConnection dBConnection { get; }

        public ConnectionHelper(string connectionString)
        {
            dBConnection = new SqlConnection(connectionString);
        }

        public int ConnectionTimeout => ((IDbConnection)dBConnection).ConnectionTimeout;

        public string Database => ((IDbConnection)dBConnection).Database;

        public ConnectionState State => ((IDbConnection)dBConnection).State;

        string IDbConnection.ConnectionString { get => dBConnection.ConnectionString; set => dBConnection.ConnectionString = value; }

        public IDbTransaction BeginTransaction()
        {
            return ((IDbConnection)dBConnection).BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return ((IDbConnection)dBConnection).BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            ((IDbConnection)dBConnection).ChangeDatabase(databaseName);
        }

        public void Close()
        {
            ((IDbConnection)dBConnection).Close();
        }

        public IDbCommand CreateCommand()
        {
            return ((IDbConnection)dBConnection).CreateCommand();
        }

        public void Dispose()
        {
            dBConnection.Dispose();
        }

        public void Open()
        {
            ((IDbConnection)dBConnection).Open();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HouseMoneyAPI.Helpers
{
    public class ConnectionHelper : IDbConnection
    {
        private SqlConnection dBConnection { get; }

        public ConnectionHelper(string connectionString) => dBConnection = new SqlConnection(connectionString);

        public int ConnectionTimeout => dBConnection.ConnectionTimeout;

        public string Database => dBConnection.Database;

        public ConnectionState State => dBConnection.State;

        public string ConnectionString { get => this.dBConnection.ConnectionString; set => this.dBConnection.ConnectionString = value; }

        public IDbTransaction BeginTransaction() => dBConnection.BeginTransaction();

        public IDbTransaction BeginTransaction(IsolationLevel il) => dBConnection.BeginTransaction(il);

        public void ChangeDatabase(string databaseName) => dBConnection.ChangeDatabase(databaseName);

        public void Close() => dBConnection.Close();

        public IDbCommand CreateCommand() => dBConnection.CreateCommand();

        public void Dispose() => dBConnection.Dispose();

        public void Open() => throw new NotImplementedException();

        public async Task OpenAsync() => await dBConnection.OpenAsync();

    }
}

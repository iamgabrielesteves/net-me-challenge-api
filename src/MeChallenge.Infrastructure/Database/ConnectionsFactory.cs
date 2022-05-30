namespace MeChallenge.Infrastructure.Database
{
    using Application.Configuration.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ConnectionsFactory : IConnectionFactory, IDisposable
    {
        private readonly string _databaseConnectionString;

        private IDbConnection _connection;

        public ConnectionsFactory(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        public IDbConnection GetOpenSqlConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_databaseConnectionString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection is {State: ConnectionState.Open})
            {
                _connection.Dispose();
            }
        }
    }
}
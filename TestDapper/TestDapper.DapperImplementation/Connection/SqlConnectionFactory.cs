using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using TestDapper.IRepositories;

namespace TestDapper.DapperImplementation.Connection
{
    public class SqlConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string connectionString;

        public SqlConnectionFactory(string connectionString) => this.connectionString = connectionString ??
            throw new ArgumentNullException(nameof(connectionString));

        public async Task<DbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}

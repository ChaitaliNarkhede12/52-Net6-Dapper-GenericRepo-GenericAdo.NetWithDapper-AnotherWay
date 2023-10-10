using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.Domain.Extensions;
using TCCS.Domain.Models;

namespace TCCS.Domain.SQLConnections
{
    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly DatabaseConnectionWithoutCredentials _databaseConnection;

        public SqlConnectionProvider(DatabaseConnectionWithoutCredentials databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<SqlConnector> GetCatalogConnection()
        {
            var connection = await _databaseConnection.GetConnectionForDataBaseWithoutCredentials(_databaseConnection.DatabaseName);
            return new SqlConnector { SqlConnection = connection };
        }

        public async Task<SqlConnector> GetDatabaseConnection()
        {
            var connection = await _databaseConnection.GetConnectionForDataBaseWithoutCredentials(_databaseConnection.DatabaseName);
            return new SqlConnector { SqlConnection = connection };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.Domain.Models;

namespace TCCS.Domain.Extensions
{
    public static class SqlConnectionExtensions
    {
        internal static async Task<SqlConnection> GetConnectionForDataBaseWithoutCredentials(this DatabaseConnectionWithoutCredentials dbConnection, string databaseName, bool enableReadOnly = false)
        {
            var connectionString = enableReadOnly && dbConnection.IsReadOnly
                ? $"{string.Format(dbConnection.ConnectionStringTemplate, dbConnection.ServerName, databaseName)};ApplicationIntent=ReadOnly;"
                : string.Format(dbConnection.ConnectionStringTemplate, dbConnection.ServerName, databaseName);

            var sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        internal static async Task<SqlConnection> GetConnectionForDataBaseWithCredentials(this DatabaseConnectionWithCredentials dbConnection, string databaseName, bool enableReadOnly = false)
        {
            var securityConfig = bool.Parse(dbConnection.UseSqlPassword) ? $"User Id={dbConnection.SQLUserName};Password={dbConnection.SQPassword};" : "";
            var connectionString = enableReadOnly && dbConnection.IsReadOnly
                ? $"{string.Format(dbConnection.ConnectionStringTemplate, dbConnection.ServerName, databaseName, securityConfig)};ApplicationIntent=ReadOnly;"
                : string.Format(dbConnection.ConnectionStringTemplate, dbConnection.ServerName, databaseName, securityConfig);

            var sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
}

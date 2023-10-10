using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.Domain.Interfaces;
using TCCS.Domain.SQLConnections;

namespace TCCS.Domain.Repositories
{
    public class Repository : IRepository
    {
        private readonly ISqlConnectionProvider _connectionProvider;

        private readonly ISqlCommandWrapper _sqlCommandWrapper;

        public Repository(ISqlConnectionProvider connectionProvider,
            ISqlCommandWrapper sqlCommandWrapper)
        {
            _connectionProvider = connectionProvider;
            _sqlCommandWrapper = sqlCommandWrapper;
        }

        public async Task<IEnumerable<T>> GetList<T>(string spName)
        {
            var sqlConnector = await _connectionProvider.GetDatabaseConnection().ConfigureAwait(false);

            var result = await _sqlCommandWrapper.QueryAllAsync<T>(sqlConnector,spName,null).ConfigureAwait(false);

            return result;

        }

        public async Task<T> GetById<T>(string spName, DynamicParameters parameters)
        {
            var sqlConnector = await _connectionProvider.GetDatabaseConnection().ConfigureAwait(false);

            var result = await _sqlCommandWrapper.QueryAsync<T>(sqlConnector, spName, parameters).ConfigureAwait(false);

            return result;
        }

        public async Task<int> AddAsync<T>(string spName, DynamicParameters parameters)
        {
            var sqlConnector = await _connectionProvider.GetDatabaseConnection().ConfigureAwait(false);

            var result = await _sqlCommandWrapper.ExecuteAsync<T>(sqlConnector, spName, parameters).ConfigureAwait(false);

            return result;
        }

        public async Task<int> UpdateAsync<T>(string spName, DynamicParameters parameters)
        {
            var sqlConnector = await _connectionProvider.GetDatabaseConnection().ConfigureAwait(false);

            var result = await _sqlCommandWrapper.ExecuteAsync<T>(sqlConnector, spName, parameters).ConfigureAwait(false);

            return result;
        }

        public async Task<int> RemoveAsync<T>(string spName, DynamicParameters parameters)
        {
            var sqlConnector = await _connectionProvider.GetDatabaseConnection().ConfigureAwait(false);

            var result = await _sqlCommandWrapper.ExecuteAsync<T>(sqlConnector, spName, parameters).ConfigureAwait(false);

            return result;
        }


    }
}

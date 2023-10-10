using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCS.Domain.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetList<T>(string spName);

        Task<T> GetById<T>(string spName,DynamicParameters parameters);

        Task<int> AddAsync<T>(string spName,DynamicParameters parameters);

        Task<int> UpdateAsync<T>(string spName,DynamicParameters parameters);

        Task<int> RemoveAsync<T>(string spName,DynamicParameters parameters);
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Interfaces;
using TCCS.DataAccess.Models;
using TCCS.Domain.Interfaces;
using static Dapper.SqlMapper;

namespace TCCS.DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IRepository _repo;

        public StudentRepository(IRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Student>> GetList()
        {
            var res = await _repo.GetList<Student>("[dbo].[GetStudentsList]");
            return res;
        }

        public async Task<Student> GetById(int id)
        {
            var dbParameter = new DynamicParameters();
            dbParameter.Add("Id", id, System.Data.DbType.String);

            var res = await _repo.GetById<Student>("[dbo].[GetStudentById]", dbParameter);
            return res;
        }

        public async Task<int> AddAsync(Student entity)
        {
            var dbParameter = new DynamicParameters();
            dbParameter.Add("Name", entity.Name, System.Data.DbType.String);
            dbParameter.Add("EmailId", entity.EmailId, System.Data.DbType.String);

            var res = await _repo.AddAsync<Student>("[dbo].[CreateStudent]", dbParameter);
            return res;
        }

        public async Task<int> UpdateAsync(Student entity)
        {
            var dbParameter = new DynamicParameters();
            dbParameter.Add("Id", entity.Id, System.Data.DbType.String);
            dbParameter.Add("Name", entity.Name, System.Data.DbType.String);
            dbParameter.Add("EmailId", entity.EmailId, System.Data.DbType.String);

            var res = await _repo.AddAsync<Student>("[dbo].[UpdateStudent]", dbParameter);
            return res;
        }


        public async Task<int> RemoveAsync(int id)
        {
            var dbParameter = new DynamicParameters();
            dbParameter.Add("Id", id, System.Data.DbType.String);

            var res = await _repo.AddAsync<Student>("[dbo].[DeleteStudent]", dbParameter);
            return res;
        }

     
    }
}

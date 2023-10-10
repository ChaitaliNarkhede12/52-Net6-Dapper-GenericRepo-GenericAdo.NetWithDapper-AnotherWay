using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;

namespace TCCS.DataAccess.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetList();

        Task<Student> GetById(int id);

        Task<int> AddAsync(Student entity);

        Task<int> UpdateAsync(Student entity);

        Task<int> RemoveAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProj.Repositories
{
    interface IRepositoryAsync<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}

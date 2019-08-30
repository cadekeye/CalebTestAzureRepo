using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2.Repositories
{
    public interface IRepository<T> where T : class {
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        Task<T> GetAllById(int id);
        IQueryable<T> GetNextEntities(string sql, object[] param);
    }
}

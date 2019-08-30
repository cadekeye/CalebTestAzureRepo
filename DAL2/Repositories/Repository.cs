using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;

namespace DAL2.Repositories
{
    public class Repository<T> : IRepository<T> where T : class {
        private readonly RestaurantDBEntities restaurantDbContext;
        public Repository(RestaurantDBEntities restaurantDbContext)
        {
            this.restaurantDbContext = restaurantDbContext;
        }

        public void Add(T entity) {
            restaurantDbContext.Set<T>().Add(entity);
        }

        public void Remove(T entity) {
            restaurantDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll() {
            return restaurantDbContext.Set<T>().ToList();
            //return restaurantDbContext.Database.SqlQuery<T>("SELECT * from orders").ToList();
        }

        public async Task<T> GetAllById(int id) {
            return await restaurantDbContext.Set<T>().FindAsync();
        }

        public IQueryable<T> GetNextEntities(string sql, object[] param) {
            return restaurantDbContext.Database.SqlQuery<T>(sql, param).AsQueryable();
        }
    }
}

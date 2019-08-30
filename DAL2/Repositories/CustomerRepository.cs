using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;

namespace DAL2.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly RestaurantDBEntities restaurantDbContext;

        public CustomerRepository(RestaurantDBEntities restaurantDbContext) : base(restaurantDbContext) {
            this.restaurantDbContext = restaurantDbContext;
        }
        public IQueryable<Customer> GetNextCustomers(int skip, int take) {
            var query = from a in this.restaurantDbContext.Customers
                orderby a.CustomerID
                select a;

           return query.Skip(skip).Take(take);
        }
    }
}

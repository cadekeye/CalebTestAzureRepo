using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;

namespace DAL2.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository {
        private readonly RestaurantDBEntities restaurantDbContext;
        public OrderRepository(RestaurantDBEntities restaurantDbContext) : base(restaurantDbContext) {
            this.restaurantDbContext = restaurantDbContext;
        }

        public IQueryable<Order> GetNextOrders(int skip, int take) {
            return this.restaurantDbContext.Database.SqlQuery<Order>(@"select * from Orders order by OrderID offset @p1 rows fetch next @p2 rows only",
                                                               new Object[] { new SqlParameter("@p1", skip), new SqlParameter("@p2", take), }).AsQueryable();
        }
    }
}

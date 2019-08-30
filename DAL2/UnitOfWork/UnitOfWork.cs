using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;
using DAL2.Repositories;

namespace DAL2.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork {
        public UnitOfWork(RestaurantDBEntities restaurantDbContext) {
            this.OrderRepository = new OrderRepository(restaurantDbContext);
            this.CustomerRepository = new CustomerRepository(restaurantDbContext);
        }

        public IOrderRepository OrderRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;
using DAL2.UnitOfWork;

namespace DAL2.Services
{
    public class OrderService {
        private readonly IUnitOfWork unitOfWork;
        public OrderService() {
           var restaurantDbContext = new RestaurantDBEntities();
            unitOfWork = new UnitOfWork.UnitOfWork(restaurantDbContext);
        }

        public void AddOrder(Order order) {
            unitOfWork.OrderRepository.Add(order);
        }

        public IQueryable<Order> GetNextOrder(int offset, int count) {
            return this.unitOfWork.OrderRepository.GetNextOrders(offset, count);
        }
    }
}

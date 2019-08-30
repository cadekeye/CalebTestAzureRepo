using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;

namespace DAL2.Repositories
{
    public interface IOrderRepository : IRepository<Order> {
        IQueryable<Order> GetNextOrders(int skip, int take);
    }
}

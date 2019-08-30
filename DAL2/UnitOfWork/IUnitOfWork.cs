using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Repositories;

namespace DAL2.UnitOfWork
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
    }
}

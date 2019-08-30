using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;

namespace DAL2.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetNextCustomers(int skip, int take);
    }
}

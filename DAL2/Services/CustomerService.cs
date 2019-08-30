using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;
using DAL2.UnitOfWork;

namespace DAL2.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerService() {
            var restaurantDbContext = new RestaurantDBEntities();
            unitOfWork = new UnitOfWork.UnitOfWork(restaurantDbContext);
        }

        public IQueryable<Customer> GetNextCustomers(int skip, int take)
        {
            return this.unitOfWork.CustomerRepository.GetNextCustomers(skip, take);
        }

        public IEnumerable<Customer> GetCustomers() {
            return this.unitOfWork.CustomerRepository.GetAll();
        }
    }
}

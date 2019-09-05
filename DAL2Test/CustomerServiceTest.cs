using System;
using System.Linq;
using DAL2.Models;
using DAL2.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL2Test
{
    [TestClass]
    public class CustomerServiceTest {
        private readonly IUnitOfWork unitOfWork;
        public CustomerServiceTest() {
            unitOfWork = new UnitOfWork(new RestaurantDBEntities());
        }
        [TestMethod]
        public void GetCustomers_Works() {
            var expected = new Customer { Name = "Tolu Paul" };
            this.unitOfWork.CustomerRepository.Add(expected);

            var actual = this.unitOfWork.CustomerRepository.GetAll().FirstOrDefault(x=>x.Name == "Tolu Paul");

            Assert.AreEqual(expected, actual);
        }
    }
}

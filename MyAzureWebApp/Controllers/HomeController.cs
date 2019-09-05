using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL2.Models;
using DAL2.Services;

namespace MyAzureWebApp.Controllers
{
    public class HomeController : Controller {
        private readonly OrderService orderService = new OrderService();
        private readonly CustomerService customerService = new CustomerService();

        public ActionResult Index() {
           // var nextOrder = orderService.GetNextOrder(1, 1).ToList();

          //var nextCustomers = customerService.GetNextCustomers(1, 1).ToList();

          var allCustomers = customerService.GetCustomerBySqlCommand("select * from customers"); //customerService.GetCustomers();

            return View(allCustomers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
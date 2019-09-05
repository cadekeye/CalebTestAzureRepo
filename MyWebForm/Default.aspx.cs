using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL2.Services;

namespace MyWebForm
{
    public partial class _Default : Page {
        private CustomerService customerService = null;
        protected void Page_Load(object sender, EventArgs e) {
            this.customerService = new CustomerService();
        }

        protected void btnLoad_OnClick(object sender, EventArgs e) {
           var customers = this.customerService.GetCustomerBySqlCommand("select * from customers");
           rptCustomers.DataSource = customers;
           rptCustomers.DataBind();
        }

        protected void rptCustomers_OnItemDataBound(object sender, RepeaterItemEventArgs e) {
            //throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentGateway_MVC.Controllers
{
    public class CustomerViewController : Controller
    {
        // GET: CustomerView
        public ActionResult addCustomerDetails()
        {
            return View();
        }
    }
}
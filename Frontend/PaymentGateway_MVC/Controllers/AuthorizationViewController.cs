using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentGateway_MVC.Controllers
{
    public class AuthorizationViewController : Controller
    {
        // GET: AuthorizationView
        public ActionResult AuthoirzationResult ()
        {
            return View();
        }
    }
}
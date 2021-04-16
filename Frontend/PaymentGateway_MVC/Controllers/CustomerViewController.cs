using PaymentGateway_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace PaymentGateway_MVC.Controllers
{
    public class CustomerViewController : Controller
    {
        // GET: CustomerView
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64189/api/student");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Customer>("CustomerDetails", customer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(customer);
        }
    }
}

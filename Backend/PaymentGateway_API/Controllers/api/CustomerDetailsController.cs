using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaymentGateway_API.DAL;
using PaymentGateway_API.Models;

namespace PaymentGateway_API.Controllers.api
{
    public class CustomerDetailsController : ApiController
    {

        public IHttpActionResult GetAllCustomerData()
        {
            return Ok();
        } //GET


        [HttpPost]
        public IHttpActionResult EnterCustomerData(Customer customer) //POST
        {
            return Json(customer);
        }

        
    }
}

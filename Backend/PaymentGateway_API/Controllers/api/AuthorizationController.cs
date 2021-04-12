using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaymentGateway_API.Controllers.api
{
    public class AuthorizationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Authorize(int customer_id, string token, DateTime time) //POST
        {
            return Ok();
        }
    }
}

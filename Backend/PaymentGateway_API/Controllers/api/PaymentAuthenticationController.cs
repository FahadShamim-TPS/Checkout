using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaymentGateway_API.Controllers.api
{
    public class PaymentAuthenticationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Authenticate(int payment_id, int amount, int customer_id, int token_id) //POST
        {
            return Ok();
        }

    }
}

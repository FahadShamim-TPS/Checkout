using PaymentGateway_API.DAL;
using PaymentGateway_API.Models;
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

        [HttpGet]
        public IHttpActionResult GetPaymentAuthenticationDetails()
        {
            IList<Payment> payments = null;

            using (var ctx = new MonetaEntities())
            {
                payments = ctx.PaymentDetails.Select(cd => new Payment()
                {
                    payment_id = cd.PaymentId,
                    customer_id = cd.CustomerID,
                    amount = cd.PaymentAmount,
                    token_id = cd.TokenID
                }).ToList<Payment>();
            }

            if (payments.Count == 0)
            {
                return NotFound();
            }

            return Ok(payments);
        }




        //[HttpGet]
        //public IHttpActionResult GetDetailsForAuthentication(int customer_id, int token_id) //POST
        //{
        //    IList<Payment> payment = null;

        //    using (var query = new MonetaEntities())
        //    {
        //        payment = query.PaymentDetails.Select(p => new Payment()
        //        {
        //            payment_id = p.PaymentId,
        //            token_id = Convert.ToInt32(p.TokenID),
        //            customer_id = Convert.ToInt32(p.CustomerID)

        //        }).ToList<Payment>();
        //    }

        //    if (payment.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(payment);

        //}


        [HttpPost]
        public IHttpActionResult PostDetailsForAuthentication(int customer_id, int token_id, int amount) //POST
        {
            using (var query = new MonetaEntities())
            {
                query.PaymentDetails.Add(new PaymentDetail()
                {
                    PaymentAmount = amount,
                    TokenID = token_id,
                    CustomerID = customer_id
                });

                query.SaveChanges();
            }
            
            return Ok();

        }

    }
}

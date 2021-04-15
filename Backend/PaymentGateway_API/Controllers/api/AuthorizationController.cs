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
    public class AuthorizationController : ApiController
    {

        [HttpPost]
        [Route("api/GetAuthorizationDetails")]
        public IHttpActionResult GetAuthorizationDetails(GetAuthorizationDetailRequest request)
        {
            using (var query2 = new MonetaEntities())
            {
                var appCall = (from app in query2.TokenDetails
                               where app.CustomerID == request.id
                               select app
                               ).FirstOrDefault();

                if (appCall == null)
                {
                    return NotFound();
                }

                var response = new
                {
                    appCall.CustomerID,
                    appCall.TokenCode,
                    appCall.TokenID,
                    appCall.Date
                };


                return Json(response);

            }
        }
  


        //post authorization
        [HttpPost]
        public IHttpActionResult Authorize(int customerId, string tokenCode, DateTime tokentime) //POST
        {
            using (var query = new MonetaEntities())
            {
                var customer_id = query.TokenDetails
                                    .Where(t => t.CustomerID == customerId && t.TokenCode == tokenCode)
                                    .Select(i => i.CustomerID).FirstOrDefault();

                var token = query.TokenDetails
                                    .Where(t => t.CustomerID == customerId && t.TokenCode == tokenCode)
                                    .Select(i => i.TokenCode).FirstOrDefault();

                var DbTokentime = query.TokenDetails
                                    .Where(t => t.CustomerID == customerId && t.TokenCode == tokenCode)
                                    .Select(i => i.Date).FirstOrDefault();

                DateTime d1 = Convert.ToDateTime(DbTokentime);
                string _tokenCreatedTime = d1.ToString("hh:mm tt");


                DateTime d2 = DateTime.Now;
                string _clientSideTime = d2.ToString("hh:mm tt");

                DateTime tokenCreatedTime = Convert.ToDateTime(_tokenCreatedTime);
                DateTime clientSideTime = Convert.ToDateTime(_clientSideTime);

                double TimeDifference = clientSideTime.Subtract(tokenCreatedTime).TotalMinutes;


                if (customer_id == Convert.ToInt32(customerId) && token == Convert.ToString(tokenCode) && TimeDifference < 15)
                {
                    var response = new
                    {
                        status = "Authorized",
                        message = "Payment has been Authorized!"
                    };

                    return Json(response);
                }

                else if (customer_id == Convert.ToInt32(customerId) && token == Convert.ToString(tokenCode) && TimeDifference > 15)
                {
                    var response = new
                    {
                        status = "Unauthorized",
                        message = "Your Token has expired!"
                    };

                    return Json(response);
                }
            }

            return Ok();
        }

    }
}



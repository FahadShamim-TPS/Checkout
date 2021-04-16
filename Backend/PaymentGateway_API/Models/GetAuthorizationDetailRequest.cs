using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentGateway_API.Models
{
    public class GetAuthorizationDetailRequest
    {
        public int id { get; set; }
        public Token token { get; set; }
    }
}
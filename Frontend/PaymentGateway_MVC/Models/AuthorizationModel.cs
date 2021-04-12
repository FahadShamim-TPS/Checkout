using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentGateway_MVC.Models
{
    public class AuthorizationModel
    {
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public TokenModel myToken { get; set; }
        public DateTime date { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentGateway_MVC.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public int Amount { get; set; }

        public int TokenID { get; set; }

        public int CustomerID { get; set; }
    }
}

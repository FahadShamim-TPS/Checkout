using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentGateway_MVC.Models
{
    public class Token
    {
        public int TokenID { get; set; }
        public string TokenCode { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
    }
}
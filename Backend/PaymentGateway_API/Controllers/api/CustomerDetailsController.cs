using System;
using System.Linq;
using System.Web.Http;
using PaymentGateway_API.DAL;
using PaymentGateway_API.Models;

namespace PaymentGateway_API.Controllers.api
{
    public class CustomerDetailsController : ApiController
    {

        //public IHttpActionResult GetAllCustomerData()
        //{
        //    return Ok();
        //} //GET


        [HttpPost]
        public IHttpActionResult EnterCustomerData(Customer customer) //POST
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            //Randomly generating salt for hash encryption
            Guid saltGuid = Guid.NewGuid();


            //Add customer data in database along with salt value
            using (var query = new MonetaEntities())
            {
                query.CustomerDetails.Add(new CustomerDetail()
                {
                    //CustomerID = customer.CustomerID,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    City = customer.City,
                    ZipCode = customer.ZipCode,
                    Email = customer.Email,
                    CardNumber = customer.CardNumber,
                    CVV_Code = customer.CVV_Code,
                    Expiration = customer.Expiration,
                    Salt = saltGuid.ToString()
                });

                query.SaveChanges();
            }

            string hash = GenerateToken(customer.FirstName,
                                        customer.CardNumber, customer.CVV_Code,
                                        saltGuid.ToString());

            //Adding Token to Token Table in Token DB
            using (var query = new MonetaEntities())
            {
                var customer_id = query.CustomerDetails
                                    .Where(c => c.CardNumber == customer.CardNumber)
                                    .Select(x => x.CustomerID).Single();

                //int debugger = Convert.ToInt32(customer_id);

                query.TokenDetails.Add(new TokenDetail()
                {
                    TokenCode = hash,
                    //Date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "yyyy-MM-dd",
                    //                   System.Globalization.CultureInfo.InvariantCulture),
                    Date = DateTime.Now,
                    CustomerID = Convert.ToInt32(customer_id)
                });
                query.SaveChanges();
            }

            //filling payment table
            using (var query = new MonetaEntities())
            {

                query.PaymentDetails.Add(new PaymentDetail()
                {
                    TokenID = getTokenId(hash),
                    CustomerID = getCustomerId(hash)
                    
                });
                query.SaveChanges();
            }


            //return Ok(hash); //200
            var multipleValues = new
            {
                token = hash,
                customerId = getCustomerId(hash)

            };

            return Json(multipleValues);
        }


        //Getting token generating functions from path: Hashing/StringCipher
        private string GenerateToken(string cus_name, long card_num, int cvv, string salt)
        {
            string Customerdetails = cus_name + "," + card_num + "," + cvv;
            string encryptedstring = StringCipher.Encrypt(Customerdetails, salt);

            return encryptedstring;
        }


        private string DecrpytToken(string hash, string salt)
        {
            string decryptedstring = StringCipher.Decrypt(hash, salt);
            return decryptedstring;
        }


        private int getCustomerId(string hash)
        {
            using (var idQuery = new MonetaEntities())
            {
                var customer_id = idQuery.TokenDetails
                                    .Where(t => t.TokenCode == hash)
                                    .Select(x => x.CustomerID).Single();

                return Convert.ToInt32(customer_id);
            }

        }

        private int getTokenId(string hash)
        {
            using (var idQuery = new MonetaEntities())
            {
                var token_id = idQuery.TokenDetails
                                    .Where(t => t.TokenCode == hash)
                                    .Select(x => x.TokenID).Single();

                return Convert.ToInt32(token_id);
            }

        }


    }
}

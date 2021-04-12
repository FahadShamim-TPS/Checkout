//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaymentGateway_API.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerDetail()
        {
            this.PaymentDetails = new HashSet<PaymentDetail>();
            this.TokenDetails = new HashSet<TokenDetail>();
        }
    
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> ZipCode { get; set; }
        public string Email { get; set; }
        public Nullable<long> CardNumber { get; set; }
        public Nullable<int> CVV_Code { get; set; }
        public Nullable<System.DateTime> Expiration { get; set; }
        public string Salt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TokenDetail> TokenDetails { get; set; }
    }
}
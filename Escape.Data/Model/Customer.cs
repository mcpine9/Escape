using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerContacts = new HashSet<CustomerContact>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("CustomerContact")]
    public partial class CustomerContact
    {
        public int CustomerContactId { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Phone2 { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Comments { get; set; }

        public DateTime DateAdded { get; set; }

        public int? Customer_CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class QuoteViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        [MaxLength(25)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Company { get; set; }
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Work Phone")]
        [MaxLength(17)]
        public string Phone { get; set; }
        [Display(Name = "Mobile Phone")]
        [MaxLength(17)]
        public string Phone2 { get; set; }
        [MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string Address2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string Zip { get; set; }
        [MaxLength(2000, ErrorMessage = "2000 Characters is the limit. You have gone over the limit.")]
        [Display(Name = "Do you have Questions or Comments?")]
        public string Comments { get; set; }

        public ShoppingCart ShoppingCart { get; set; } 
    }
}
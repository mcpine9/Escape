using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class ProductsAdminDetailsViewModel
    {
        public Product Product { get; set; }
        [Display(Name = "Selected Categories")]
        public Dictionary<int, string> SelectedCategories { get; set; }
    }
}
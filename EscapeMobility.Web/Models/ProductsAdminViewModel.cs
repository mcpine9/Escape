using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class ProductsAdminViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        [Display(Name = "Category")]
        public IEnumerable<Category> ProductCategoryList { get; set; }
        public List<int> SelectedProductCategoryIds { get; set; }
        [Display(Name = "Selected Categories")]
        public Dictionary<int, string> SelectedCategories { get; set; }
        [Display(Name = "Evacuation Type")]
        public string SelectedEvacuationType { get; set; }
        [Display(Name = "Safety Type")]
        public string SelectedSafetyType { get; set; }
    }
}
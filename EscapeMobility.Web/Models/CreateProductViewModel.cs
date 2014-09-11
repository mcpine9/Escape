using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }
        [Display(Name = "Category")]
        public IEnumerable<Category> ProductCategoryList { get; set; }
        [Required]
        public List<int> SelectedProductCategoryIds { get; set; }
        [Display(Name = "Evacuation Type")]
        [Required]
        public List<SelectListItem> EvacuationTypeList { get; set; }
        [Display(Name = "Safety Type")]
        [Required]
        public List<SelectListItem> SafetyTypeList { get; set; }
    }
}
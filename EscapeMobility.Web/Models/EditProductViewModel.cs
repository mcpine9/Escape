using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        [Display(Name = "Category")]
        public IEnumerable<Category> ProductCategoryList { get; set; }
        public List<int> SelectedProductCategoryIds { get; set; }
        [Display(Name = "Evacuation Type")]
        public List<SelectListItem> EvacuationTypeList { get; set; }
        [Display(Name = "Safety Type")]
        public List<SelectListItem> SafetyTypeList { get; set; }
    }
}
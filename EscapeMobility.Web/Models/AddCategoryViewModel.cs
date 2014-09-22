using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class AddCategoryViewModel
    {
        [Display(Name = "Category Name")]
        [Required]
        public string CategoryName { get; set; }
    }
}
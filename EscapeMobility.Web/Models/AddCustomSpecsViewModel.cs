using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class AddCustomSpecsViewModel
    {
        public int productId { get; set; }
        public string json { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Show")]   
        public bool Show { get; set; }
        [Display(Name = "Show In Production")]
        public bool ShowInProd { get; set; }
    }
}

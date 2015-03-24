using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class ProductHighlightModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string ImageFileName { get; set; }
        public bool HasSpec { get; set; }
        public bool Show { get; set; }
        public bool ShowInProd { get; set; }
        public bool IsDev { get; set; }
    }
}
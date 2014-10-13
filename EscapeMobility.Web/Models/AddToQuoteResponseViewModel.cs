using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class AddToQuoteViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string ImageFileName { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class CustomSpecsViewModel
    {
        public int CustomSpecificationId { get; set; }
        public string CustomSpecJSONObject { get; set; }
        public Product Product { get; set; }
    }
}
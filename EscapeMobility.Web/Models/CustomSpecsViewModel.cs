using System.Collections.Generic;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class CustomSpecsViewModel
    {
        public int CustomSpecificationId { get; set; }
        public string CustomSpecJSONObject { get; set; }
        public IEnumerable<Product> LinkedProducts { get; set; }
    }
}
using System;
using System.Collections.Generic;
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data.Model
{
    [Table("CustomSpecification")]
    public class CustomSpecification
    {
        public int CustomSpecificationId { get; set; }
        public string SpecificationObject { get; set; }

        public ICollection<Product> Products { get; set; }

        public CustomSpecification()
        {
            Products = new HashSet<Product>();
        }
    }
}

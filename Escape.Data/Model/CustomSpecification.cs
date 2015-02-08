using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data.Model
{
    public class CustomSpecification
    {
        public int ID { get; set; }
        public string SpecificationObject { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}

using System.Collections;
using System.Collections.Generic;

namespace Escape.Data.Model
{
    public class SafetyCategory
    {
        public int SafetyCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
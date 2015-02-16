using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("SafetyCategory")]
    public partial class SafetyCategory
    {
        public SafetyCategory()
        {
            Products = new HashSet<Product>();
        }

        public int SafetyCategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

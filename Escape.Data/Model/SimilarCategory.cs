using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("SimilarCategory")]
    public partial class SimilarCategory
    {
        public SimilarCategory()
        {
            Products = new HashSet<Product>();
        }

        public int SimilarCategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

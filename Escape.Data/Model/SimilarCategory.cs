using System.Collections.Generic;

namespace Escape.Data.Model
{
    public class SimilarCategory
    {
        public int SimilarCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data.Model
{
    public class Product
    {   
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Thumbnailfolder { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public long ArticleNumber { get; set; }
        public string VideoSample { get; set; }
        public string SafetyTags { get; set; }
        public string SimilarTags { get; set; }
        public int ProductSpecificationId { get; set; }

        public virtual ICollection<Category> ProductCategories { get; set; }
        public virtual ICollection<SafetyCategory> SafetyCategories { get; set; }
        public virtual ICollection<SimilarCategory> SimilarCategories { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; } 
 
    }
}

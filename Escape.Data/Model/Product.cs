using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            Accessories = new HashSet<Accessory>();
            Categories = new HashSet<Category>();
            SafetyCategories = new HashSet<SafetyCategory>();
            SimilarCategories = new HashSet<SimilarCategory>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Thumbnailfolder { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public long ArticleNumber { get; set; }

        public string VideoSampleURL { get; set; }

        public string SafetyTags { get; set; }

        public string RelatedTags { get; set; }

        public bool IsAccessory { get; set; }

        public string ImageFileName { get; set; }

        public int ProductSpecificationId { get; set; }

        public int EvacuationType { get; set; }

        public int SafetyType { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual ProductSpecification ProductSpecification { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<SafetyCategory> SafetyCategories { get; set; }

        public virtual ICollection<SimilarCategory> SimilarCategories { get; set; }

        public virtual ICollection<CustomSpecification> CustomSpecifications { get; set; }
    }
}

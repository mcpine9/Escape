using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data.Model
{
    public class Product
    {
        public Product()
        {
            CustomSpecifications = new HashSet<CustomSpecification>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }
        [Display(Name = "Thumbnail Folder")]
        public string Thumbnailfolder { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        [Required]
        [Display(Name = "Article Number")]
        public long ArticleNumber { get; set; }
        [Display(Name = "Video Sample URL")]
        public string VideoSampleURL { get; set; }
        [Display(Name = "Safety Tags")]
        public string SafetyTags { get; set; }
        [Display(Name = "Related Tags")]
        public string RelatedTags { get; set; }
        [Display(Name = "Is an Accessory")]
        public bool IsAccessory { get; set; }
        [Display(Name = "Image File Name")]
        public string ImageFileName { get; set; }
        public int ProductSpecificationId { get; set; }
        public EvacuationType EvacuationType { get; set; }
        public SafetyType SafetyType { get; set; }

        public virtual ProductSpecification ProductSpecification { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<SafetyCategory> SafetyCategories { get; set; }
        public virtual ICollection<SimilarCategory> SimilarCategories { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<CustomSpecification> CustomSpecifications { get; set; } 
    }
}

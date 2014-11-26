using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escape.Data.Model;

namespace Escape.Data.DataMappings
{
    class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasRequired(s => s.ProductSpecification).WithRequiredPrincipal().WillCascadeOnDelete(true);
            HasMany(c => c.Categories)
                .WithMany(p => p.Products)
                .Map(t => t.MapLeftKey("ProductId")
                .MapRightKey("CategoryId").ToTable("ProductCategory"));
            HasMany(s => s.SafetyCategories).WithMany(p => p.Products);
            HasMany(s => s.SimilarCategories).WithMany(p => p.Products);
            HasMany(s => s.Accessories).WithMany(p => p.Products);
        }
    }
}
    
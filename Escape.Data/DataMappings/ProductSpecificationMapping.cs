using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Escape.Data.Model;

namespace Escape.Data.DataMappings
{
    class ProductSpecificationMapping : EntityTypeConfiguration<ProductSpecification>
    {
        public ProductSpecificationMapping()
        {
            HasKey(s => s.ProductSpecificationId);
        }
    }
}
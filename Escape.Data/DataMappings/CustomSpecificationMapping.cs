using System.Data.Entity.ModelConfiguration;
using Escape.Data.Model;

namespace Escape.Data.DataMappings
{
    public class CustomSpecificationMapping : EntityTypeConfiguration<CustomSpecification>
    {
        public CustomSpecificationMapping()
        {
            HasRequired(p => p.Products);
        }
    }
}
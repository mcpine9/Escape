using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using Escape.Data.Model;

namespace Escape.Data
{
    public class EscapeDataInitializer : DropCreateDatabaseAlways<EscapeDataContext>
    {
        
        protected override void Seed(EscapeDataContext context)
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    ArticleNumber = 1000010,
                    LongDescription = "This model has basic features only. This Escape-Chair® is most suitable when you need a minimum evacuation aid in a (public) building or when you prefer a basic model for budgetary reasons. This model can also be fitted with a footrest and/or ‘extra package’.",
                    Price = 1295.00M,
                    ShortDescription = "Light weight basic evacuation chair with aluminum frame.",
                    Title = "Escape-Chair® Standard-ALU",
                    IsAccessory = false
                },
                new Product()
                {
                    ArticleNumber = 1000015,
                    LongDescription = "",
                    Price = 1445.00M,
                    ShortDescription = "Light weight basic evacuation chair with additional package: standard seat with extra fixation. Padded (upholstered) headrest. Anti-slip on operating handle and lower frame.",
                    Title = "Escape-Chair® Standard-ALU with extra package",
                    IsAccessory = false
                },
                new Product()
                {
                    ArticleNumber = 1000020,
                    LongDescription = "",
                    Price = 1595.00M,
                    ShortDescription = "Light weight basic evacuation chair with enamelled aluminum frame.",
                    Title = "Escape-Chair® Standard",
                    IsAccessory = false
                },
                new Product()
                {
                    ArticleNumber = 1000030,
                    LongDescription = "",
                    Price = 1895.00M,
                    ShortDescription = "Light weight evacuation chair with in 2 height positions adjustable operating handle and comfort seat.",
                    Title = "Escape-Chair® StandardPLUS",
                    IsAccessory = false
                },
                new Product()
                {
                    ArticleNumber = 1000040,
                    LongDescription = "",
                    Price = 2495.00M,
                    ShortDescription = "Evacuation chair with armrests, footrest, in 2 height positions adjustable operating handle and comfort seat.",
                    Title = "Escape-Chair® Comfort",
                    IsAccessory = false
                }
            };

            products.ForEach(p => context.Product.Add(p));
            context.SaveChanges();
            SqlConnection.ClearAllPools();
        }
    }
}

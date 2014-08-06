using System.Collections.Generic;
using Escape.Data.Model;

namespace Escape.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Escape.Data.EscapeDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Escape.Data.EscapeDataContext context)
        {

            //var products = new List<Product>()
            //{
            //    new Product()
            //    {
            //        ArticleNumber = 1000010,
            //        LongDescription = "",
            //        Price = 1295.00M,
            //        ShortDescription = "Light weight basic evacuation chair with aluminum frame.",
            //        Title = "Escape-Chair® Standard-ALU"
            //    },
            //    new Product()
            //    {
            //        ArticleNumber = 1000015,
            //        LongDescription = "",
            //        Price = 1445.00M,
            //        ShortDescription = "Light weight basic evacuation chair with additional package: standard seat with extra fixation. Padded (upholstered) headrest. Anti-slip on operating handle and lower frame.",
            //        Title = "Escape-Chair® Standard-ALU with extra package"
            //    },
            //    new Product()
            //    {
            //        ArticleNumber = 1000020,
            //        LongDescription = "",
            //        Price = 1595.00M,
            //        ShortDescription = "Light weight basic evacuation chair with enamelled aluminum frame.",
            //        Title = "Escape-Chair® Standard"
            //    },
            //    new Product()
            //    {
            //        ArticleNumber = 1000030,
            //        LongDescription = "",
            //        Price = 1895.00M,
            //        ShortDescription = "Light weight evacuation chair with in 2 height positions adjustable operating handle and comfort seat.",
            //        Title = "Escape-Chair® StandardPLUS"
            //    },
            //    new Product()
            //    {
            //        ArticleNumber = 1000040,
            //        LongDescription = "",
            //        Price = 2495.00M,
            //        ShortDescription = "Evacuation chair with armrests, footrest, in 2 height positions adjustable operating handle and comfort seat.",
            //        Title = "Escape-Chair® Comfort"
            //    }
            //};

            //products.ForEach(p => context.Products.AddOrUpdate(x => x.ProductId, p));
            //context.SaveChanges();
        }
    }
}

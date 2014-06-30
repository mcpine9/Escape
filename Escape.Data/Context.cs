using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data
{
    class Context : DbContext
    {
        public Context() : base("Default")
        {
            
        }

        DbSet<MainProductInfo> MainProductInfo { get; set; }
        DbSet<ProductSpecifications> ProductSpecification { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerContactInfo> CustomerContactInformation { get; set; }
        DbSet<ShoppinCart> ShoppingCarts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; } 
    }
}

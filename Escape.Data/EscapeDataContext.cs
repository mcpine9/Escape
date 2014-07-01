using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escape.Data.Model;

namespace Escape.Data
{
    class EscapeDataContext : DbContext
    {
        DbSet<Product> MainProductInfo { get; set; }
        DbSet<ProductSpecification> ProductSpecification { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerContact> CustomerContactInformation { get; set; }
        DbSet<ShoppingCart> ShoppingCarts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Diagnostics;
using Escape.Data.DataMappings;
using Escape.Data.Model;        

namespace Escape.Data
{
    public class EscapeDataContext : DbContext
    {
        public EscapeDataContext()
            : base("EscapeDataContext")
        {
            Debug.Write(Database.Connection.ConnectionString);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductSpecification> ProductSpecification { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerContact> CustomerContact { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SafetyCategory> SafetyCategory { get; set; }
        public DbSet<SimilarCategory> SimilarCategory { get; set; }
        public DbSet<CustomSpecification> CustomSpecification { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new ProductSpecificationMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}

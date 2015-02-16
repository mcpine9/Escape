using Escape.Data.Model;

namespace Escape.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EscapeDataModel : DbContext
    {
        public EscapeDataModel()
            : base("name=EscapeDataModel")
        {
        }

        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public virtual DbSet<SafetyCategory> SafetyCategories { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<SimilarCategory> SimilarCategories { get; set; }
        public virtual DbSet<CustomSpecification> CustomeSpecifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Accessories)
                .Map(m => m.ToTable("ProductAccessory"));

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("ProductCategory").MapLeftKey("CategoryId").MapRightKey("ProductId"));

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerContacts)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ShoppingCarts)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_CustomerId);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.ProductSpecification)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SafetyCategories)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProductSafetyCategory"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SimilarCategories)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProductSimilarCategory"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CustomSpecifications)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProductCustomSpecification")
                            .MapLeftKey("ProductId")
                            .MapRightKey("CustomSpecificationId"));
        }
    }
}

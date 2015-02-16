namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessory",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AccessoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Thumbnailfolder = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        ArticleNumber = c.Long(nullable: false),
                        VideoSampleURL = c.String(),
                        SafetyTags = c.String(),
                        RelatedTags = c.String(),
                        IsAccessory = c.Boolean(nullable: false),
                        ImageFileName = c.String(),
                        ProductSpecificationId = c.Int(nullable: false),
                        EvacuationType = c.Int(nullable: false),
                        SafetyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        ShoppingCartID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCart", t => t.ShoppingCartID, cascadeDelete: true)
                .Index(t => t.ShoppingCartID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Message = c.String(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.ShoppingCartId)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerContact",
                c => new
                    {
                        CustomerContactId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Company = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Phone2 = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Comments = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerContactId)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.CustomSpecification",
                c => new
                    {
                        CustomSpecificationId = c.Int(nullable: false, identity: true),
                        SpecificationObject = c.String(),
                    })
                .PrimaryKey(t => t.CustomSpecificationId);
            
            CreateTable(
                "dbo.ProductSpecification",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Material = c.String(),
                        IsEasyToOperate = c.Boolean(nullable: false),
                        IsReadyForUse = c.Boolean(nullable: false),
                        HasUnfoldingStand = c.Boolean(nullable: false),
                        HasErgonomicBackrest = c.Boolean(nullable: false),
                        HasGlidingBeltSystem = c.Boolean(nullable: false),
                        HasDustCover = c.Boolean(nullable: false),
                        HasAniSlipHandle = c.Boolean(nullable: false),
                        MaxCarryingCapacity = c.String(),
                        MaxAngleOfStairs = c.String(),
                        OperatingHandle = c.String(),
                        Seat = c.String(),
                        Backrest = c.String(),
                        Footrest = c.String(),
                        Armrest = c.String(),
                        HasImmobilizationBand = c.Boolean(nullable: false),
                        DimensionsFoldedUp = c.String(),
                        Weight = c.String(),
                        HasPaddedHeadRest = c.Boolean(nullable: false),
                        LimitedWarranty = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SafetyCategory",
                c => new
                    {
                        SafetyCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SafetyCategoryId);
            
            CreateTable(
                "dbo.SimilarCategory",
                c => new
                    {
                        SimilarCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SimilarCategoryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.ProductId })
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductCustomSpecification",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CustomSpecificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CustomSpecificationId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.CustomSpecification", t => t.CustomSpecificationId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomSpecificationId);
            
            CreateTable(
                "dbo.ProductSafetyCategory",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        SafetyCategory_SafetyCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.SafetyCategory_SafetyCategoryId })
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.SafetyCategory", t => t.SafetyCategory_SafetyCategoryId, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.SafetyCategory_SafetyCategoryId);
            
            CreateTable(
                "dbo.ProductSimilarCategory",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        SimilarCategory_SimilarCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.SimilarCategory_SimilarCategoryId })
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.SimilarCategory", t => t.SimilarCategory_SimilarCategoryId, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.SimilarCategory_SimilarCategoryId);
            
            CreateTable(
                "dbo.ProductAccessory",
                c => new
                    {
                        Accessory_AccessoryId = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Accessory_AccessoryId, t.Product_Id })
                .ForeignKey("dbo.Accessory", t => t.Accessory_AccessoryId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Accessory_AccessoryId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductAccessory", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.ProductAccessory", "Accessory_AccessoryId", "dbo.Accessory");
            DropForeignKey("dbo.ProductSimilarCategory", "SimilarCategory_SimilarCategoryId", "dbo.SimilarCategory");
            DropForeignKey("dbo.ProductSimilarCategory", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.ProductSafetyCategory", "SafetyCategory_SafetyCategoryId", "dbo.SafetyCategory");
            DropForeignKey("dbo.ProductSafetyCategory", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.ProductSpecification", "Id", "dbo.Product");
            DropForeignKey("dbo.ProductCustomSpecification", "CustomSpecificationId", "dbo.CustomSpecification");
            DropForeignKey("dbo.ProductCustomSpecification", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ShoppingCart", "Customer_CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CustomerContact", "Customer_CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CartItem", "ShoppingCartID", "dbo.ShoppingCart");
            DropForeignKey("dbo.CartItem", "ProductID", "dbo.Product");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.ProductAccessory", new[] { "Product_Id" });
            DropIndex("dbo.ProductAccessory", new[] { "Accessory_AccessoryId" });
            DropIndex("dbo.ProductSimilarCategory", new[] { "SimilarCategory_SimilarCategoryId" });
            DropIndex("dbo.ProductSimilarCategory", new[] { "Product_Id" });
            DropIndex("dbo.ProductSafetyCategory", new[] { "SafetyCategory_SafetyCategoryId" });
            DropIndex("dbo.ProductSafetyCategory", new[] { "Product_Id" });
            DropIndex("dbo.ProductCustomSpecification", new[] { "CustomSpecificationId" });
            DropIndex("dbo.ProductCustomSpecification", new[] { "ProductId" });
            DropIndex("dbo.ProductCategory", new[] { "ProductId" });
            DropIndex("dbo.ProductCategory", new[] { "CategoryId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.ProductSpecification", new[] { "Id" });
            DropIndex("dbo.CustomerContact", new[] { "Customer_CustomerId" });
            DropIndex("dbo.ShoppingCart", new[] { "Customer_CustomerId" });
            DropIndex("dbo.CartItem", new[] { "ProductID" });
            DropIndex("dbo.CartItem", new[] { "ShoppingCartID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ProductAccessory");
            DropTable("dbo.ProductSimilarCategory");
            DropTable("dbo.ProductSafetyCategory");
            DropTable("dbo.ProductCustomSpecification");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SimilarCategory");
            DropTable("dbo.SafetyCategory");
            DropTable("dbo.ProductSpecification");
            DropTable("dbo.CustomSpecification");
            DropTable("dbo.Category");
            DropTable("dbo.CustomerContact");
            DropTable("dbo.Customer");
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.CartItem");
            DropTable("dbo.Product");
            DropTable("dbo.Accessory");
        }
    }
}

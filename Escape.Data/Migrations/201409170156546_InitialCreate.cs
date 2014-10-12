namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        ShoppingCartID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCart", t => t.ShoppingCartID, cascadeDelete: true)
                .Index(t => t.ShoppingCartID)
                .Index(t => t.ProductID);

            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.ProductId);

            CreateTable(
                "dbo.Accessory",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AccessoryId);

            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.ProductSpecification",
                c => new
                    {
                        ProductSpecificationId = c.Int(nullable: false),
                        IsSpecificationOn = c.Boolean(nullable: false),
                        Material = c.String(),
                        IsEasyToOperate = c.Boolean(nullable: false),
                        IsReadyForUse = c.Boolean(nullable: false),
                        HasUnfoldingStand = c.Boolean(nullable: false),
                        HasErgonomicBackrest = c.Boolean(nullable: false),
                        HasGlidingBeltSystem = c.Boolean(nullable: false),
                        HasDustCover = c.Boolean(nullable: false),
                        HasAniSlipHandle = c.Boolean(nullable: false),
                        MaxCarryingCapacity = c.Int(),
                        MaxAngleOfStairs = c.Int(),
                        OperatingHandle = c.String(),
                        Seat = c.String(),
                        Backrest = c.String(),
                        Footrest = c.String(),
                        Armrest = c.String(),
                        HasImmobilizationBand = c.Boolean(nullable: false),
                        HasPaddedHeadrest = c.Boolean(nullable: false),
                        DimentionsFoldedUp = c.String(),
                        Waranty = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSpecificationId)
                .ForeignKey("dbo.Product", t => t.ProductSpecificationId)
                .Index(t => t.ProductSpecificationId);

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
                "dbo.ShoppingCart",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Message = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);

            CreateTable(
                "dbo.CustomerContact",
                c => new
                    {
                        CustomerContactId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Phone = c.String(),
                        Phone2 = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerContactId)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);

            CreateTable(
                "dbo.ProductAccessory",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Accessory_AccessoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Accessory_AccessoryId })
                .ForeignKey("dbo.Product", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Accessory", t => t.Accessory_AccessoryId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Accessory_AccessoryId);

            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CategoryId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.ProductSafetyCategory",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        SafetyCategory_SafetyCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.SafetyCategory_SafetyCategoryId })
                .ForeignKey("dbo.Product", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SafetyCategory", t => t.SafetyCategory_SafetyCategoryId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.SafetyCategory_SafetyCategoryId);

            CreateTable(
                "dbo.ProductSimilarCategory",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        SimilarCategory_SimilarCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.SimilarCategory_SimilarCategoryId })
                .ForeignKey("dbo.Product", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SimilarCategory", t => t.SimilarCategory_SimilarCategoryId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.SimilarCategory_SimilarCategoryId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCart", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CustomerContact", "Customer_CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CartItem", "ShoppingCartID", "dbo.ShoppingCart");
            DropForeignKey("dbo.CartItem", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductSimilarCategory", "SimilarCategory_SimilarCategoryId", "dbo.SimilarCategory");
            DropForeignKey("dbo.ProductSimilarCategory", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductSafetyCategory", "SafetyCategory_SafetyCategoryId", "dbo.SafetyCategory");
            DropForeignKey("dbo.ProductSafetyCategory", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductSpecification", "ProductSpecificationId", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ProductCategory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductAccessory", "Accessory_AccessoryId", "dbo.Accessory");
            DropForeignKey("dbo.ProductAccessory", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.ProductSimilarCategory", new[] { "SimilarCategory_SimilarCategoryId" });
            DropIndex("dbo.ProductSimilarCategory", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductSafetyCategory", new[] { "SafetyCategory_SafetyCategoryId" });
            DropIndex("dbo.ProductSafetyCategory", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductCategory", new[] { "CategoryId" });
            DropIndex("dbo.ProductCategory", new[] { "ProductId" });
            DropIndex("dbo.ProductAccessory", new[] { "Accessory_AccessoryId" });
            DropIndex("dbo.ProductAccessory", new[] { "Product_ProductId" });
            DropIndex("dbo.CustomerContact", new[] { "Customer_CustomerId" });
            DropIndex("dbo.ShoppingCart", new[] { "CustomerId" });
            DropIndex("dbo.ProductSpecification", new[] { "ProductSpecificationId" });
            DropIndex("dbo.CartItem", new[] { "ProductID" });
            DropIndex("dbo.CartItem", new[] { "ShoppingCartID" });
            DropTable("dbo.ProductSimilarCategory");
            DropTable("dbo.ProductSafetyCategory");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.ProductAccessory");
            DropTable("dbo.CustomerContact");
            DropTable("dbo.Customer");
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.SimilarCategory");
            DropTable("dbo.SafetyCategory");
            DropTable("dbo.ProductSpecification");
            DropTable("dbo.Category");
            DropTable("dbo.Accessory");
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
        }
    }
}

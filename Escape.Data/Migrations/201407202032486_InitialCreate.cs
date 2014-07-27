namespace Escape.Data.Migrations
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
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        Title = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        SpecificationId = c.Int(nullable: false),
                        Thumbnailfolder = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArticleNumber = c.Long(nullable: false),
                        VideoSample = c.String(),
                        SafetyTags = c.String(),
                        SimilarTags = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Accessory",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        AccessoryToPublic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.SafetyCategory",
                c => new
                    {
                        SafetyCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.SafetyCategoryId)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.SimilarCategory",
                c => new
                    {
                        SimilarCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.SimilarCategoryId)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Message = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
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
                "dbo.ProductSpecification",
                c => new
                    {
                        ProductSpecificationId = c.Int(nullable: false, identity: true),
                        IsSpecificationOn = c.Boolean(nullable: false),
                        Material = c.String(),
                        IsEasyToOperate = c.Boolean(nullable: false),
                        IsReadyForUse = c.Boolean(nullable: false),
                        HasUnfoldingStand = c.Boolean(nullable: false),
                        HasErgonomicBackrest = c.Boolean(nullable: false),
                        HasGlidingBeltSystem = c.Boolean(nullable: false),
                        HasDustCover = c.Boolean(nullable: false),
                        HasAniSlipHandle = c.Boolean(nullable: false),
                        MaxCarryingCapacity = c.Int(nullable: false),
                        MaxAngleOfStairs = c.Int(nullable: false),
                        OperatingHandle = c.String(),
                        Seat = c.String(),
                        Backrest = c.String(),
                        Footrest = c.String(),
                        Armrest = c.String(),
                        HasImmobilizationBand = c.Boolean(nullable: false),
                        HasPaddedHeadrest = c.Boolean(nullable: false),
                        DimentionsFoldedUp = c.String(),
                        Waranty = c.String(),
                    })
                .PrimaryKey(t => t.ProductSpecificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerContact", "Customer_CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CartItem", "ShoppingCartID", "dbo.ShoppingCart");
            DropForeignKey("dbo.CartItem", "ProductID", "dbo.Product");
            DropForeignKey("dbo.SimilarCategory", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.SafetyCategory", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Category", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Accessory", "ProductId", "dbo.Product");
            DropIndex("dbo.CustomerContact", new[] { "Customer_CustomerId" });
            DropIndex("dbo.SimilarCategory", new[] { "Product_ProductId" });
            DropIndex("dbo.SafetyCategory", new[] { "Product_ProductId" });
            DropIndex("dbo.Category", new[] { "Product_ProductId" });
            DropIndex("dbo.Accessory", new[] { "ProductId" });
            DropIndex("dbo.CartItem", new[] { "ProductID" });
            DropIndex("dbo.CartItem", new[] { "ShoppingCartID" });
            DropTable("dbo.ProductSpecification");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerContact");
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.SimilarCategory");
            DropTable("dbo.SafetyCategory");
            DropTable("dbo.Category");
            DropTable("dbo.Accessory");
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
        }
    }
}

namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProductSpecification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductSpecification", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.ProductSpecification", new[] { "ProductSpecificationId" });
            DropIndex("dbo.ProductSpecification", new[] { "Product_ProductId" });
            DropPrimaryKey("dbo.ProductSpecification");
            AlterColumn("dbo.ProductSpecification", "ProductSpecificationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductSpecification", "ProductSpecificationId");
            CreateIndex("dbo.ProductSpecification", "ProductSpecificationId");
            DropColumn("dbo.ProductSpecification", "ProductId");
            DropColumn("dbo.ProductSpecification", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSpecification", "Product_ProductId", c => c.Int());
            AddColumn("dbo.ProductSpecification", "ProductId", c => c.Int(nullable: false));
            DropIndex("dbo.ProductSpecification", new[] { "ProductSpecificationId" });
            DropPrimaryKey("dbo.ProductSpecification");
            AlterColumn("dbo.ProductSpecification", "ProductSpecificationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductSpecification", "ProductSpecificationId");
            CreateIndex("dbo.ProductSpecification", "Product_ProductId");
            CreateIndex("dbo.ProductSpecification", "ProductSpecificationId");
            AddForeignKey("dbo.ProductSpecification", "Product_ProductId", "dbo.Product", "ProductId");
        }
    }
}

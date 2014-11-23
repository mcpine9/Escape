namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProductSpecRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductSpecification", "ProductSpecificationId", "dbo.Product");
            AddColumn("dbo.ProductSpecification", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.ProductSpecification", "Product_ProductId");
            AddForeignKey("dbo.ProductSpecification", "Product_ProductId", "dbo.Product", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSpecification", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.ProductSpecification", new[] { "Product_ProductId" });
            DropColumn("dbo.ProductSpecification", "Product_ProductId");
            AddForeignKey("dbo.ProductSpecification", "ProductSpecificationId", "dbo.Product", "ProductId");
        }
    }
}

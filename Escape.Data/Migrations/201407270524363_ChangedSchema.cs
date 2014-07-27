namespace Escape.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductSpecification_ProductSpecificationId", c => c.Int());
            AddColumn("dbo.ProductSpecification", "ProductId", c => c.Int());
            AlterColumn("dbo.Product", "SpecificationId", c => c.Int());
            AlterColumn("dbo.Product", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ProductSpecification", "MaxCarryingCapacity", c => c.Int());
            AlterColumn("dbo.ProductSpecification", "MaxAngleOfStairs", c => c.Int());
            CreateIndex("dbo.Product", "ProductSpecification_ProductSpecificationId");
            AddForeignKey("dbo.Product", "ProductSpecification_ProductSpecificationId", "dbo.ProductSpecification", "ProductSpecificationId");
            DropColumn("dbo.CartItem", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItem", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Product", "ProductSpecification_ProductSpecificationId", "dbo.ProductSpecification");
            DropIndex("dbo.Product", new[] { "ProductSpecification_ProductSpecificationId" });
            AlterColumn("dbo.ProductSpecification", "MaxAngleOfStairs", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductSpecification", "MaxCarryingCapacity", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "SpecificationId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductSpecification", "ProductId");
            DropColumn("dbo.Product", "ProductSpecification_ProductSpecificationId");
        }
    }
}

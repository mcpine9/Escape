namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductProdSpecRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductSpecification", "ProductSpecificationId", "dbo.Product");
            DropIndex("dbo.ProductSpecification", new[] { "ProductSpecificationId" });
            DropPrimaryKey("dbo.ProductSpecification");
            AddColumn("dbo.ProductSpecification", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductSpecification", "ProductSpecificationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductSpecification", "ProductId");
            CreateIndex("dbo.ProductSpecification", "ProductId");
            AddForeignKey("dbo.ProductSpecification", "ProductId", "dbo.Product", "ProductId");
            DropColumn("dbo.ProductSpecification", "IsSpecificationOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSpecification", "IsSpecificationOn", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ProductSpecification", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductSpecification", new[] { "ProductId" });
            DropPrimaryKey("dbo.ProductSpecification");
            AlterColumn("dbo.ProductSpecification", "ProductSpecificationId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ProductSpecification", "ProductId");
            AddPrimaryKey("dbo.ProductSpecification", "ProductSpecificationId");
            CreateIndex("dbo.ProductSpecification", "ProductSpecificationId");
            AddForeignKey("dbo.ProductSpecification", "ProductSpecificationId", "dbo.Product", "ProductId");
        }
    }
}

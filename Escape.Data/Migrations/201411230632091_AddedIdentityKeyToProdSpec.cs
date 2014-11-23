namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIdentityKeyToProdSpec : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductSpecification", new[] { "ProductSpecificationId" });
            DropPrimaryKey("dbo.ProductSpecification");
            AlterColumn("dbo.ProductSpecification", "ProductSpecificationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductSpecification", "ProductSpecificationId");
            CreateIndex("dbo.ProductSpecification", "ProductSpecificationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductSpecification", new[] { "ProductSpecificationId" });
            DropPrimaryKey("dbo.ProductSpecification");
            AlterColumn("dbo.ProductSpecification", "ProductSpecificationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductSpecification", "ProductSpecificationId");
            CreateIndex("dbo.ProductSpecification", "ProductSpecificationId");
        }
    }
}

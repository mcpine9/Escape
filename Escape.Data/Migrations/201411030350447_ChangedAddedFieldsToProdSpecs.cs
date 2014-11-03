namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAddedFieldsToProdSpecs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSpecification", "Warranty", c => c.String());
            AddColumn("dbo.ProductSpecification", "Weight", c => c.String());
            AddColumn("dbo.ProductSpecification", "Dimensions", c => c.String());
            AddColumn("dbo.ProductSpecification", "LimitedWarranty", c => c.String());
            DropColumn("dbo.ProductSpecification", "Waranty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSpecification", "Waranty", c => c.String());
            DropColumn("dbo.ProductSpecification", "LimitedWarranty");
            DropColumn("dbo.ProductSpecification", "Dimensions");
            DropColumn("dbo.ProductSpecification", "Weight");
            DropColumn("dbo.ProductSpecification", "Warranty");
        }
    }
}

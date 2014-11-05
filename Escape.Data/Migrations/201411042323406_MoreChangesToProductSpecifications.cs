namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreChangesToProductSpecifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSpecification", "DimensionsFoldedUp", c => c.String());
            DropColumn("dbo.ProductSpecification", "DimentionsFoldedUp");
            DropColumn("dbo.ProductSpecification", "LimitedWarranty");
            DropColumn("dbo.ProductSpecification", "ArticleNumber");
            DropColumn("dbo.ProductSpecification", "Discount");
            DropColumn("dbo.ProductSpecification", "ImageFileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSpecification", "ImageFileName", c => c.String());
            AddColumn("dbo.ProductSpecification", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.ProductSpecification", "ArticleNumber", c => c.Long(nullable: false));
            AddColumn("dbo.ProductSpecification", "LimitedWarranty", c => c.String());
            AddColumn("dbo.ProductSpecification", "DimentionsFoldedUp", c => c.String());
            DropColumn("dbo.ProductSpecification", "DimensionsFoldedUp");
        }
    }
}

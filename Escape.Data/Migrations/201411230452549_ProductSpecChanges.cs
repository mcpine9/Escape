namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductSpecChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductSpecification", "Warranty");
            DropColumn("dbo.ProductSpecification", "Dimensions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSpecification", "Dimensions", c => c.String());
            AddColumn("dbo.ProductSpecification", "Warranty", c => c.String());
        }
    }
}

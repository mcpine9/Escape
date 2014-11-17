namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustedProductSpecification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSpecification", "LimitedWarranty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSpecification", "LimitedWarranty");
        }
    }
}

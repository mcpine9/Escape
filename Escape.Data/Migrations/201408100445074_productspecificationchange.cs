namespace Escape.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productspecificationchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSpecification", "ProductSpecificationID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSpecification", "ProductSpecificationID");
        }
    }
}

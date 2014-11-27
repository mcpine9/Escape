namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProductandSpec : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "ProductSpecificationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductSpecificationId", c => c.Int(nullable: false));
        }
    }
}

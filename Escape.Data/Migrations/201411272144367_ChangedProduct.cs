namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductSpecificationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductSpecificationId");
        }
    }
}

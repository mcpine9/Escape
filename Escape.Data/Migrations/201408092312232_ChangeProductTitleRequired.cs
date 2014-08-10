namespace Escape.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductTitleRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Title", c => c.String());
        }
    }
}

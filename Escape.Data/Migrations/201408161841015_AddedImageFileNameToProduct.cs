namespace Escape.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageFileNameToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImageFileName");
        }
    }
}

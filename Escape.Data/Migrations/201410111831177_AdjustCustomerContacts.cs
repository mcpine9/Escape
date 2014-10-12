namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustCustomerContacts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerContact", "Title", c => c.String());
            AddColumn("dbo.CustomerContact", "Company", c => c.String());
            AddColumn("dbo.CustomerContact", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customer", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Title", c => c.String());
            DropColumn("dbo.CustomerContact", "DateAdded");
            DropColumn("dbo.CustomerContact", "Company");
            DropColumn("dbo.CustomerContact", "Title");
            DropColumn("dbo.Customer", "DateCreated");
        }
    }
}

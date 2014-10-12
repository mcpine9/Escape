namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCommmentsToCustomerContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerContact", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerContact", "Comments");
        }
    }
}

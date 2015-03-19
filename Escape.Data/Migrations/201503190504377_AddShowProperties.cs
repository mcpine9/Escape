namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomSpecification", "Show", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomSpecification", "ShowInProd", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomSpecification", "ShowInProd");
            DropColumn("dbo.CustomSpecification", "Show");
        }
    }
}

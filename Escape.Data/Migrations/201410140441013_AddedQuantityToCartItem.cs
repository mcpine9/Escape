namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuantityToCartItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItem", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItem", "Quantity");
        }
    }
}

namespace Escape.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductSpecChanges1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductSpecification", "MaxCarryingCapacity", c => c.String());
            AlterColumn("dbo.ProductSpecification", "MaxAngleOfStairs", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSpecification", "MaxAngleOfStairs", c => c.Int());
            AlterColumn("dbo.ProductSpecification", "MaxCarryingCapacity", c => c.Int());
        }
    }
}

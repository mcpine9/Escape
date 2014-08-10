namespace Escape.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProductsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "VideoSampleURL", c => c.String());
            AddColumn("dbo.Product", "RelatedTags", c => c.String());
            AddColumn("dbo.Product", "IsAccessory", c => c.Boolean(nullable: false));
            DropColumn("dbo.Product", "VideoSample");
            DropColumn("dbo.Product", "SimilarTags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "SimilarTags", c => c.String());
            AddColumn("dbo.Product", "VideoSample", c => c.String());
            DropColumn("dbo.Product", "IsAccessory");
            DropColumn("dbo.Product", "RelatedTags");
            DropColumn("dbo.Product", "VideoSampleURL");
        }
    }
}

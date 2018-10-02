namespace webApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTagModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.Blogs", new[] { "Tag_TagId" });
            DropColumn("dbo.Blogs", "Tag_TagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Tag_TagId", c => c.Int());
            CreateIndex("dbo.Blogs", "Tag_TagId");
            AddForeignKey("dbo.Blogs", "Tag_TagId", "dbo.Tags", "TagId");
        }
    }
}

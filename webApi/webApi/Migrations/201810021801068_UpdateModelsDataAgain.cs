namespace webApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsDataAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "TagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "TagId", c => c.Int(nullable: false));
        }
    }
}

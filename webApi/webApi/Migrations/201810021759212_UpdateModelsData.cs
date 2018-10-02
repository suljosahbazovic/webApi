namespace webApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "TagId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "TagId");
        }
    }
}

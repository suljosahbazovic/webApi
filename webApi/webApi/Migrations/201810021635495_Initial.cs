namespace webApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(nullable: false, maxLength: 1000),
                        Title = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(),
                        Body = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Blog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id)
                .Index(t => t.Blog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Blog_Id", "dbo.Blogs");
            DropIndex("dbo.Tags", new[] { "Blog_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Blogs");
        }
    }
}

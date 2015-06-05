namespace BlogSeymaCengiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Files", new[] { "ArticleID" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        ReleaseTime = c.DateTime(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateIndex("dbo.Files", "ArticleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Files", new[] { "ArticleId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.Comments");
            CreateIndex("dbo.Files", "ArticleID");
        }
    }
}

namespace BlogSeymaCengiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "ArticleID", "dbo.Articles");
            DropIndex("dbo.FilePaths", new[] { "ArticleID" });
            AlterColumn("dbo.Articles", "Title", c => c.String(maxLength: 50));
            DropTable("dbo.FilePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        ArticleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId);
            
            AlterColumn("dbo.Articles", "Title", c => c.String(maxLength: 100));
            CreateIndex("dbo.FilePaths", "ArticleID");
            AddForeignKey("dbo.FilePaths", "ArticleID", "dbo.Articles", "ArticleID", cascadeDelete: true);
        }
    }
}

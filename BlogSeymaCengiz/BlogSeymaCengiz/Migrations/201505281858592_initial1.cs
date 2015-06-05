namespace BlogSeymaCengiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Image");
        }
    }
}

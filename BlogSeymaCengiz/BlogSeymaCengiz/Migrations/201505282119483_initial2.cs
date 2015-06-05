namespace BlogSeymaCengiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Image", c => c.String());
        }
    }
}

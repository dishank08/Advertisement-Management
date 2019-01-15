namespace OnlineAdvertisingPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.BusinessDetails", "Ratings", c => c.String());
            AlterColumn("dbo.Categories", "Categoryname", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Categories", "Categoryname");
            DropColumn("dbo.Categories", "Cid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Cid", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Categoryname", c => c.String());
            AlterColumn("dbo.BusinessDetails", "Ratings", c => c.Double(nullable: false));
            AddPrimaryKey("dbo.Categories", "Cid");
        }
    }
}

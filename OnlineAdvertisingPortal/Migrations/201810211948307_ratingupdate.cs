namespace OnlineAdvertisingPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessDetails", "Overall", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessDetails", "Overall");
        }
    }
}

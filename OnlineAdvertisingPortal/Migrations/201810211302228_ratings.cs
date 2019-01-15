namespace OnlineAdvertisingPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Businessid = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        BusinessDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.BusinessDetails", t => t.BusinessDetails_Id)
                .Index(t => t.BusinessDetails_Id);
            
            DropColumn("dbo.BusinessDetails", "Ratings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessDetails", "Ratings", c => c.String());
            DropForeignKey("dbo.Ratings", "BusinessDetails_Id", "dbo.BusinessDetails");
            DropIndex("dbo.Ratings", new[] { "BusinessDetails_Id" });
            DropTable("dbo.Ratings");
        }
    }
}

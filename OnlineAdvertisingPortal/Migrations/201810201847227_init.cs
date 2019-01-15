namespace OnlineAdvertisingPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Businessname = c.String(nullable: false),
                        Ownername = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Ratings = c.Double(nullable: false),
                        Imagepath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        Categoryname = c.String(),
                        CategoryPath = c.String(),
                    })
                .PrimaryKey(t => t.Cid);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.BusinessDetails");
        }
    }
}

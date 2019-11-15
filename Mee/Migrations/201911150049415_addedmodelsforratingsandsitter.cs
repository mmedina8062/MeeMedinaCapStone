namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodelsforratingsandsitter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RateID = c.Int(nullable: false, identity: true),
                        SitterID = c.Int(nullable: false),
                        Ratings = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.RateID)
                .ForeignKey("dbo.Sitters", t => t.SitterID, cascadeDelete: true)
                .Index(t => t.SitterID);
            
            CreateTable(
                "dbo.Sitters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Details = c.String(),
                        Age = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters");
            DropForeignKey("dbo.Sitters", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sitters", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Sitters", new[] { "ApplicationId" });
            DropIndex("dbo.Sitters", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "SitterID" });
            DropTable("dbo.Sitters");
            DropTable("dbo.Ratings");
        }
    }
}

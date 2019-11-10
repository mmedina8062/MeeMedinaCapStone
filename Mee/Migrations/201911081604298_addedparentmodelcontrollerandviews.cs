namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedparentmodelcontrollerandviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Parents", new[] { "ApplicationId" });
            DropTable("dbo.Parents");
        }
    }
}

namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedforeignkeyforuseridandaddedpropertyboolcanceloraccept : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sitters", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Sitters", new[] { "UserId" });
            AddColumn("dbo.Sitters", "CancelOrAccept", c => c.Boolean(nullable: false));
            DropColumn("dbo.Sitters", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sitters", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Sitters", "CancelOrAccept");
            CreateIndex("dbo.Sitters", "UserId");
            AddForeignKey("dbo.Sitters", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}

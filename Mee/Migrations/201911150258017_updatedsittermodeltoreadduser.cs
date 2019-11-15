namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedsittermodeltoreadduser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sitters", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sitters", "UserId");
            AddForeignKey("dbo.Sitters", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sitters", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Sitters", new[] { "UserId" });
            DropColumn("dbo.Sitters", "UserId");
        }
    }
}

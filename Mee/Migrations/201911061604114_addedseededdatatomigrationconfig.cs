namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedseededdatatomigrationconfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        PreferenceID = c.Int(nullable: false, identity: true),
                        Preferences = c.String(),
                    })
                .PrimaryKey(t => t.PreferenceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Preferences");
        }
    }
}

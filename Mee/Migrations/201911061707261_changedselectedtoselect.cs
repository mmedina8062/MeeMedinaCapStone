namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedselectedtoselect : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "Select", c => c.Boolean(nullable: false));
            DropColumn("dbo.Preferences", "selected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "selected", c => c.Boolean(nullable: false));
            DropColumn("dbo.Preferences", "Select");
        }
    }
}

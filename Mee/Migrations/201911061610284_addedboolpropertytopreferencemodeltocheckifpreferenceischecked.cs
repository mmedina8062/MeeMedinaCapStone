namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedboolpropertytopreferencemodeltocheckifpreferenceischecked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "selected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "selected");
        }
    }
}

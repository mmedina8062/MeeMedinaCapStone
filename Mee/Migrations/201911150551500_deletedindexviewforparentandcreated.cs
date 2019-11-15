namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedindexviewforparentandcreated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Parents", "SelectedSitter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parents", "SelectedSitter", c => c.String());
        }
    }
}

namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdedselectedsittertoparentsmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "selectedSitter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "selectedSitter");
        }
    }
}

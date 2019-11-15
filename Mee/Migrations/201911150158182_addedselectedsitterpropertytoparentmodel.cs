namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedselectedsitterpropertytoparentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "SelectedSitter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "SelectedSitter");
        }
    }
}

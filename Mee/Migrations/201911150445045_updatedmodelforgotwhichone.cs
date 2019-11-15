namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelforgotwhichone : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sitters", "CancelOrAccept");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sitters", "CancelOrAccept", c => c.Boolean(nullable: false));
        }
    }
}

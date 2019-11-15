namespace Mee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedtypoforimagedatetoimagedata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageGalleries",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageSize = c.Int(nullable: false),
                        FileName = c.String(),
                        imageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageGalleries");
        }
    }
}

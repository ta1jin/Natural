namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "DateOfDeath", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Artists", "Birthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Paintings", "DateOfPainting", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Paintings", "DateOfPainting", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Artists", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Artists", "DateOfDeath", c => c.DateTime(nullable: false));
        }
    }
}

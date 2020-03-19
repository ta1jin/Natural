namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Surname", c => c.String());
            AddColumn("dbo.Employees", "Surname", c => c.String());
            DropColumn("dbo.Artists", "Syrname");
            DropColumn("dbo.Employees", "Syrname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Syrname", c => c.String());
            AddColumn("dbo.Artists", "Syrname", c => c.String());
            DropColumn("dbo.Employees", "Surname");
            DropColumn("dbo.Artists", "Surname");
        }
    }
}

namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaintingMovements", "GoingToSklad", c => c.Boolean(nullable: false));
            DropColumn("dbo.PaintingMovements", "GoingFromRestoration");
            DropColumn("dbo.PaintingMovements", "GoingFromExposition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaintingMovements", "GoingFromExposition", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintingMovements", "GoingFromRestoration", c => c.Boolean(nullable: false));
            DropColumn("dbo.PaintingMovements", "GoingToSklad");
        }
    }
}

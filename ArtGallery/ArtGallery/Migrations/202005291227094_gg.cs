namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaintingMovements", "Painting_Id", "dbo.Paintings");
            DropIndex("dbo.PaintingMovements", new[] { "Painting_Id" });
            RenameColumn(table: "dbo.PaintingMovements", name: "Painting_Id", newName: "PaintingId");
            AlterColumn("dbo.PaintingMovements", "PaintingId", c => c.Int(nullable: false));
            CreateIndex("dbo.PaintingMovements", "PaintingId");
            AddForeignKey("dbo.PaintingMovements", "PaintingId", "dbo.Paintings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaintingMovements", "PaintingId", "dbo.Paintings");
            DropIndex("dbo.PaintingMovements", new[] { "PaintingId" });
            AlterColumn("dbo.PaintingMovements", "PaintingId", c => c.Int());
            RenameColumn(table: "dbo.PaintingMovements", name: "PaintingId", newName: "Painting_Id");
            CreateIndex("dbo.PaintingMovements", "Painting_Id");
            AddForeignKey("dbo.PaintingMovements", "Painting_Id", "dbo.Paintings", "Id");
        }
    }
}

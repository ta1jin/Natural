namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "PaintingId", "dbo.Paintings");
            DropIndex("dbo.Reports", new[] { "PaintingId" });
            CreateTable(
                "dbo.ReportPaintings",
                c => new
                    {
                        Report_Id = c.Int(nullable: false),
                        Painting_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Report_Id, t.Painting_Id })
                .ForeignKey("dbo.Reports", t => t.Report_Id, cascadeDelete: false)
                .ForeignKey("dbo.Paintings", t => t.Painting_Id, cascadeDelete: true)
                .Index(t => t.Report_Id)
                .Index(t => t.Painting_Id);
            
            DropColumn("dbo.Reports", "PaintingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "PaintingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ReportPaintings", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.ReportPaintings", "Report_Id", "dbo.Reports");
            DropIndex("dbo.ReportPaintings", new[] { "Painting_Id" });
            DropIndex("dbo.ReportPaintings", new[] { "Report_Id" });
            DropTable("dbo.ReportPaintings");
            CreateIndex("dbo.Reports", "PaintingId");
            AddForeignKey("dbo.Reports", "PaintingId", "dbo.Paintings", "Id", cascadeDelete: true);
        }
    }
}

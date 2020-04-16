namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaintingMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ReportDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Gallery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.Gallery_Id)
                .Index(t => t.EmployeeId)
                .Index(t => t.Gallery_Id);
            
            CreateTable(
                "dbo.PaintingMovementJournals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfRecord = c.DateTime(nullable: false),
                        Description = c.String(),
                        GoingToRestoration = c.Boolean(nullable: false),
                        GoingToExposition = c.Boolean(nullable: false),
                        GoingFromRestoration = c.Boolean(nullable: false),
                        GoingFromExposition = c.Boolean(nullable: false),
                        Discarded = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.GalleryId);
            
            AddColumn("dbo.Paintings", "PaintingMovementJournal_Id", c => c.Int());
            CreateIndex("dbo.Paintings", "PaintingMovementJournal_Id");
            AddForeignKey("dbo.Paintings", "PaintingMovementJournal_Id", "dbo.PaintingMovementJournals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paintings", "PaintingMovementJournal_Id", "dbo.PaintingMovementJournals");
            DropForeignKey("dbo.PaintingMovementJournals", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.PaintingMovementJournals", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PaintingMovements", "Gallery_Id", "dbo.Galleries");
            DropForeignKey("dbo.PaintingMovements", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.PaintingMovementJournals", new[] { "GalleryId" });
            DropIndex("dbo.PaintingMovementJournals", new[] { "EmployeeId" });
            DropIndex("dbo.PaintingMovements", new[] { "Gallery_Id" });
            DropIndex("dbo.PaintingMovements", new[] { "EmployeeId" });
            DropIndex("dbo.Paintings", new[] { "PaintingMovementJournal_Id" });
            DropColumn("dbo.Paintings", "PaintingMovementJournal_Id");
            DropTable("dbo.PaintingMovementJournals");
            DropTable("dbo.PaintingMovements");
        }
    }
}

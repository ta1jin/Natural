namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaintingMovements", "Gallery_Id", "dbo.Galleries");
            DropIndex("dbo.PaintingMovements", new[] { "Gallery_Id" });
            RenameColumn(table: "dbo.PaintingMovements", name: "Gallery_Id", newName: "GalleryId");
            CreateTable(
                "dbo.Showrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Location = c.String(),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .Index(t => t.GalleryId);
            
            AddColumn("dbo.Expositions", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Expositions", "ShowroomId", c => c.Int(nullable: false));
            AddColumn("dbo.Expositions", "PaintingMovement_Id", c => c.Int());
            AddColumn("dbo.Expositions", "PaintingMovement_Id1", c => c.Int());
            AddColumn("dbo.Reports", "PaintingMovement_Id", c => c.Int());
            AddColumn("dbo.Reports", "PaintingMovement_Id1", c => c.Int());
            AddColumn("dbo.PaintingMovements", "DateOfRecord", c => c.DateTime(nullable: false));
            AddColumn("dbo.PaintingMovements", "GoingToRestoration", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintingMovements", "GoingToExposition", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintingMovements", "GoingFromRestoration", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintingMovements", "GoingFromExposition", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintingMovements", "Discarded", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintingMovements", "NameBeforeMovement", c => c.String());
            AddColumn("dbo.PaintingMovements", "NameAfterMovement", c => c.String());
            AddColumn("dbo.PaintingMovements", "DateOfPaintingBeforeMovement", c => c.DateTime(nullable: false));
            AddColumn("dbo.PaintingMovements", "DateOfPaintingAfterMovement", c => c.DateTime(nullable: false));
            AddColumn("dbo.PaintingMovements", "PriceBeforeMovement", c => c.Double(nullable: false));
            AddColumn("dbo.PaintingMovements", "PriceAfterMovement", c => c.Double(nullable: false));
            AddColumn("dbo.PaintingMovements", "StateBeforeMovement", c => c.Int(nullable: false));
            AddColumn("dbo.PaintingMovements", "StateAfterMovement", c => c.Int(nullable: false));
            AddColumn("dbo.PaintingMovements", "StatusBeforeMovement", c => c.Int(nullable: false));
            AddColumn("dbo.PaintingMovements", "StatusAfterMovement", c => c.Int(nullable: false));
            AddColumn("dbo.PaintingMovements", "Painting_Id", c => c.Int());
            AlterColumn("dbo.PaintingMovements", "GalleryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Expositions", "ShowroomId");
            CreateIndex("dbo.Expositions", "PaintingMovement_Id");
            CreateIndex("dbo.Expositions", "PaintingMovement_Id1");
            CreateIndex("dbo.Reports", "PaintingMovement_Id");
            CreateIndex("dbo.Reports", "PaintingMovement_Id1");
            CreateIndex("dbo.PaintingMovements", "GalleryId");
            CreateIndex("dbo.PaintingMovements", "Painting_Id");
            AddForeignKey("dbo.Expositions", "PaintingMovement_Id", "dbo.PaintingMovements", "Id");
            AddForeignKey("dbo.Expositions", "PaintingMovement_Id1", "dbo.PaintingMovements", "Id");
            AddForeignKey("dbo.PaintingMovements", "Painting_Id", "dbo.Paintings", "Id");
            AddForeignKey("dbo.Reports", "PaintingMovement_Id", "dbo.PaintingMovements", "Id");
            AddForeignKey("dbo.Reports", "PaintingMovement_Id1", "dbo.PaintingMovements", "Id");
            AddForeignKey("dbo.Expositions", "ShowroomId", "dbo.Showrooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaintingMovements", "GalleryId", "dbo.Galleries", "Id", cascadeDelete: false);
            DropColumn("dbo.Expositions", "Location");
            DropColumn("dbo.PaintingMovements", "ReportDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaintingMovements", "ReportDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Expositions", "Location", c => c.String());
            DropForeignKey("dbo.PaintingMovements", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Showrooms", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Expositions", "ShowroomId", "dbo.Showrooms");
            DropForeignKey("dbo.Reports", "PaintingMovement_Id1", "dbo.PaintingMovements");
            DropForeignKey("dbo.Reports", "PaintingMovement_Id", "dbo.PaintingMovements");
            DropForeignKey("dbo.PaintingMovements", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.Expositions", "PaintingMovement_Id1", "dbo.PaintingMovements");
            DropForeignKey("dbo.Expositions", "PaintingMovement_Id", "dbo.PaintingMovements");
            DropIndex("dbo.Showrooms", new[] { "GalleryId" });
            DropIndex("dbo.PaintingMovements", new[] { "Painting_Id" });
            DropIndex("dbo.PaintingMovements", new[] { "GalleryId" });
            DropIndex("dbo.Reports", new[] { "PaintingMovement_Id1" });
            DropIndex("dbo.Reports", new[] { "PaintingMovement_Id" });
            DropIndex("dbo.Expositions", new[] { "PaintingMovement_Id1" });
            DropIndex("dbo.Expositions", new[] { "PaintingMovement_Id" });
            DropIndex("dbo.Expositions", new[] { "ShowroomId" });
            AlterColumn("dbo.PaintingMovements", "GalleryId", c => c.Int());
            DropColumn("dbo.PaintingMovements", "Painting_Id");
            DropColumn("dbo.PaintingMovements", "StatusAfterMovement");
            DropColumn("dbo.PaintingMovements", "StatusBeforeMovement");
            DropColumn("dbo.PaintingMovements", "StateAfterMovement");
            DropColumn("dbo.PaintingMovements", "StateBeforeMovement");
            DropColumn("dbo.PaintingMovements", "PriceAfterMovement");
            DropColumn("dbo.PaintingMovements", "PriceBeforeMovement");
            DropColumn("dbo.PaintingMovements", "DateOfPaintingAfterMovement");
            DropColumn("dbo.PaintingMovements", "DateOfPaintingBeforeMovement");
            DropColumn("dbo.PaintingMovements", "NameAfterMovement");
            DropColumn("dbo.PaintingMovements", "NameBeforeMovement");
            DropColumn("dbo.PaintingMovements", "Discarded");
            DropColumn("dbo.PaintingMovements", "GoingFromExposition");
            DropColumn("dbo.PaintingMovements", "GoingFromRestoration");
            DropColumn("dbo.PaintingMovements", "GoingToExposition");
            DropColumn("dbo.PaintingMovements", "GoingToRestoration");
            DropColumn("dbo.PaintingMovements", "DateOfRecord");
            DropColumn("dbo.Reports", "PaintingMovement_Id1");
            DropColumn("dbo.Reports", "PaintingMovement_Id");
            DropColumn("dbo.Expositions", "PaintingMovement_Id1");
            DropColumn("dbo.Expositions", "PaintingMovement_Id");
            DropColumn("dbo.Expositions", "ShowroomId");
            DropColumn("dbo.Expositions", "Status");
            DropTable("dbo.Showrooms");
            RenameColumn(table: "dbo.PaintingMovements", name: "GalleryId", newName: "Gallery_Id");
            CreateIndex("dbo.PaintingMovements", "Gallery_Id");
            AddForeignKey("dbo.PaintingMovements", "Gallery_Id", "dbo.Galleries", "Id");
        }
    }
}

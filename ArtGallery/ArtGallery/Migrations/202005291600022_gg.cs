namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfDeath = c.DateTime(nullable: false),
                        Biography = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paintings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArtistId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        PaintingTechniqueId = c.Int(nullable: false),
                        GalleryId = c.Int(nullable: false),
                        DateOfPainting = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        State = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        PaintingMovementJournal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.PaintingTechniques", t => t.PaintingTechniqueId, cascadeDelete: true)
                .ForeignKey("dbo.PaintingMovementJournals", t => t.PaintingMovementJournal_Id)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId)
                .Index(t => t.PaintingTechniqueId)
                .Index(t => t.GalleryId)
                .Index(t => t.PaintingMovementJournal_Id);
            
            CreateTable(
                "dbo.Expositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ShowroomId = c.Int(nullable: false),
                        GalleryId = c.Int(nullable: false),
                        PaintingMovement_Id = c.Int(),
                        PaintingMovement_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .ForeignKey("dbo.PaintingMovements", t => t.PaintingMovement_Id)
                .ForeignKey("dbo.PaintingMovements", t => t.PaintingMovement_Id1)
                .ForeignKey("dbo.Showrooms", t => t.ShowroomId, cascadeDelete: true)
                .Index(t => t.ShowroomId)
                .Index(t => t.GalleryId)
                .Index(t => t.PaintingMovement_Id)
                .Index(t => t.PaintingMovement_Id1);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Email = c.String(),
                        HotLine = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        GalleryId = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.PositionId)
                .Index(t => t.GalleryId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ReportDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        GalleryId = c.Int(nullable: false),
                        PaintingMovement_Id = c.Int(),
                        PaintingMovement_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .ForeignKey("dbo.PaintingMovements", t => t.PaintingMovement_Id)
                .ForeignKey("dbo.PaintingMovements", t => t.PaintingMovement_Id1)
                .Index(t => t.EmployeeId)
                .Index(t => t.GalleryId)
                .Index(t => t.PaintingMovement_Id)
                .Index(t => t.PaintingMovement_Id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Access = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaintingMovements",
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
                        PaintingId = c.Int(nullable: false),
                        NameBeforeMovement = c.String(),
                        NameAfterMovement = c.String(),
                        DateOfPaintingBeforeMovement = c.DateTime(nullable: false),
                        DateOfPaintingAfterMovement = c.DateTime(nullable: false),
                        PriceBeforeMovement = c.Double(nullable: false),
                        PriceAfterMovement = c.Double(nullable: false),
                        StateBeforeMovement = c.Int(nullable: false),
                        StateAfterMovement = c.Int(nullable: false),
                        StatusBeforeMovement = c.Int(nullable: false),
                        StatusAfterMovement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .ForeignKey("dbo.Paintings", t => t.PaintingId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.GalleryId)
                .Index(t => t.PaintingId);
            
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
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaintingTechniques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.ReportPaintings",
                c => new
                    {
                        Report_Id = c.Int(nullable: false),
                        Painting_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Report_Id, t.Painting_Id })
                .ForeignKey("dbo.Reports", t => t.Report_Id, cascadeDelete: true)
                .ForeignKey("dbo.Paintings", t => t.Painting_Id, cascadeDelete: true)
                .Index(t => t.Report_Id)
                .Index(t => t.Painting_Id);
            
            CreateTable(
                "dbo.ExpositionPaintings",
                c => new
                    {
                        Exposition_Id = c.Int(nullable: false),
                        Painting_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exposition_Id, t.Painting_Id })
                .ForeignKey("dbo.Expositions", t => t.Exposition_Id, cascadeDelete: true)
                .ForeignKey("dbo.Paintings", t => t.Painting_Id, cascadeDelete: true)
                .Index(t => t.Exposition_Id)
                .Index(t => t.Painting_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paintings", "PaintingMovementJournal_Id", "dbo.PaintingMovementJournals");
            DropForeignKey("dbo.PaintingMovementJournals", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.PaintingMovementJournals", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Paintings", "PaintingTechniqueId", "dbo.PaintingTechniques");
            DropForeignKey("dbo.Paintings", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Showrooms", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Expositions", "ShowroomId", "dbo.Showrooms");
            DropForeignKey("dbo.ExpositionPaintings", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.ExpositionPaintings", "Exposition_Id", "dbo.Expositions");
            DropForeignKey("dbo.Paintings", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Reports", "PaintingMovement_Id1", "dbo.PaintingMovements");
            DropForeignKey("dbo.Reports", "PaintingMovement_Id", "dbo.PaintingMovements");
            DropForeignKey("dbo.PaintingMovements", "PaintingId", "dbo.Paintings");
            DropForeignKey("dbo.PaintingMovements", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Expositions", "PaintingMovement_Id1", "dbo.PaintingMovements");
            DropForeignKey("dbo.Expositions", "PaintingMovement_Id", "dbo.PaintingMovements");
            DropForeignKey("dbo.PaintingMovements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Expositions", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Employees", "Id", "dbo.Users");
            DropForeignKey("dbo.ReportPaintings", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.ReportPaintings", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.Reports", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Employees", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Paintings", "ArtistId", "dbo.Artists");
            DropIndex("dbo.ExpositionPaintings", new[] { "Painting_Id" });
            DropIndex("dbo.ExpositionPaintings", new[] { "Exposition_Id" });
            DropIndex("dbo.ReportPaintings", new[] { "Painting_Id" });
            DropIndex("dbo.ReportPaintings", new[] { "Report_Id" });
            DropIndex("dbo.PaintingMovementJournals", new[] { "GalleryId" });
            DropIndex("dbo.PaintingMovementJournals", new[] { "EmployeeId" });
            DropIndex("dbo.Showrooms", new[] { "GalleryId" });
            DropIndex("dbo.PaintingMovements", new[] { "PaintingId" });
            DropIndex("dbo.PaintingMovements", new[] { "GalleryId" });
            DropIndex("dbo.PaintingMovements", new[] { "EmployeeId" });
            DropIndex("dbo.Reports", new[] { "PaintingMovement_Id1" });
            DropIndex("dbo.Reports", new[] { "PaintingMovement_Id" });
            DropIndex("dbo.Reports", new[] { "GalleryId" });
            DropIndex("dbo.Reports", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "GalleryId" });
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.Expositions", new[] { "PaintingMovement_Id1" });
            DropIndex("dbo.Expositions", new[] { "PaintingMovement_Id" });
            DropIndex("dbo.Expositions", new[] { "GalleryId" });
            DropIndex("dbo.Expositions", new[] { "ShowroomId" });
            DropIndex("dbo.Paintings", new[] { "PaintingMovementJournal_Id" });
            DropIndex("dbo.Paintings", new[] { "GalleryId" });
            DropIndex("dbo.Paintings", new[] { "PaintingTechniqueId" });
            DropIndex("dbo.Paintings", new[] { "GenreId" });
            DropIndex("dbo.Paintings", new[] { "ArtistId" });
            DropTable("dbo.ExpositionPaintings");
            DropTable("dbo.ReportPaintings");
            DropTable("dbo.PaintingMovementJournals");
            DropTable("dbo.PaintingTechniques");
            DropTable("dbo.Genres");
            DropTable("dbo.Showrooms");
            DropTable("dbo.PaintingMovements");
            DropTable("dbo.Users");
            DropTable("dbo.Reports");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.Galleries");
            DropTable("dbo.Expositions");
            DropTable("dbo.Paintings");
            DropTable("dbo.Artists");
        }
    }
}

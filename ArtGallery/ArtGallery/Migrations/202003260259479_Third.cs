namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr : DbMigration
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
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GalleryId = c.Int(nullable: false),
                        Position = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Access = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: false)
                .Index(t => t.GalleryId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Email = c.String(),
                        HotLine = c.Long(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
            CreateTable(
                "dbo.Paintings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArtistId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        PaintingTehniqueId = c.Int(nullable: false),
                        GalleryId = c.Int(nullable: false),
                        DateOfPainting = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        State = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Exposition_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.PaintingTechniques", t => t.PaintingTehniqueId, cascadeDelete: true)
                .ForeignKey("dbo.Expositions", t => t.Exposition_Id)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId)
                .Index(t => t.PaintingTehniqueId)
                .Index(t => t.GalleryId)
                .Index(t => t.Exposition_Id);
            
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
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ReportDate = c.DateTime(nullable: false),
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
                .ForeignKey("dbo.Paintings", t => t.Painting_Id, cascadeDelete: false)
                .Index(t => t.Report_Id)
                .Index(t => t.Painting_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paintings", "Exposition_Id", "dbo.Expositions");
            DropForeignKey("dbo.ReportPaintings", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.ReportPaintings", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.Reports", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Paintings", "PaintingTehniqueId", "dbo.PaintingTechniques");
            DropForeignKey("dbo.Paintings", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Paintings", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Paintings", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Expositions", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Employees", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.ReportPaintings", new[] { "Painting_Id" });
            DropIndex("dbo.ReportPaintings", new[] { "Report_Id" });
            DropIndex("dbo.Reports", new[] { "GalleryId" });
            DropIndex("dbo.Reports", new[] { "EmployeeId" });
            DropIndex("dbo.Paintings", new[] { "Exposition_Id" });
            DropIndex("dbo.Paintings", new[] { "GalleryId" });
            DropIndex("dbo.Paintings", new[] { "PaintingTehniqueId" });
            DropIndex("dbo.Paintings", new[] { "GenreId" });
            DropIndex("dbo.Paintings", new[] { "ArtistId" });
            DropIndex("dbo.Expositions", new[] { "GalleryId" });
            DropIndex("dbo.Employees", new[] { "GalleryId" });
            DropTable("dbo.ReportPaintings");
            DropTable("dbo.Reports");
            DropTable("dbo.PaintingTechniques");
            DropTable("dbo.Genres");
            DropTable("dbo.Paintings");
            DropTable("dbo.Expositions");
            DropTable("dbo.Galleries");
            DropTable("dbo.Employees");
            DropTable("dbo.Artists");
        }
    }
}

namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lyuboe : DbMigration
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
                        GalleryId = c.Int(nullable: false),
                        Name = c.String(),
                        Syrname = c.String(),
                        Patronymic = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
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
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Access = c.String(),
                        GalleryId = c.Int(nullable: false),
                        Name = c.String(),
                        Syrname = c.String(),
                        Patronymic = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ReportDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        PaintingId = c.Int(nullable: false),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .ForeignKey("dbo.Paintings", t => t.PaintingId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PaintingId)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artists", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Paintings", "Exposition_Id", "dbo.Expositions");
            DropForeignKey("dbo.Expositions", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Reports", "PaintingId", "dbo.Paintings");
            DropForeignKey("dbo.Paintings", "PaintingTehniqueId", "dbo.PaintingTechniques");
            DropForeignKey("dbo.Paintings", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Paintings", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Paintings", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Reports", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.Expositions", new[] { "GalleryId" });
            DropIndex("dbo.Paintings", new[] { "Exposition_Id" });
            DropIndex("dbo.Paintings", new[] { "GalleryId" });
            DropIndex("dbo.Paintings", new[] { "PaintingTehniqueId" });
            DropIndex("dbo.Paintings", new[] { "GenreId" });
            DropIndex("dbo.Paintings", new[] { "ArtistId" });
            DropIndex("dbo.Reports", new[] { "GalleryId" });
            DropIndex("dbo.Reports", new[] { "PaintingId" });
            DropIndex("dbo.Reports", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "GalleryId" });
            DropIndex("dbo.Artists", new[] { "GalleryId" });
            DropTable("dbo.Expositions");
            DropTable("dbo.PaintingTechniques");
            DropTable("dbo.Genres");
            DropTable("dbo.Paintings");
            DropTable("dbo.Reports");
            DropTable("dbo.Employees");
            DropTable("dbo.Galleries");
            DropTable("dbo.Artists");
        }
    }
}


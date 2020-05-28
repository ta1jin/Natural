namespace ArtGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PaintingMovements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PaintingMovementJournals", "EmployeeId", "dbo.Employees");
            DropPrimaryKey("dbo.Employees");
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Employees", "PositionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.Employees", "Id");
            CreateIndex("dbo.Employees", "PositionId");
            AddForeignKey("dbo.Employees", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaintingMovements", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaintingMovementJournals", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "Position");
            DropColumn("dbo.Employees", "Login");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "Access");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Access", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "Login", c => c.String());
            AddColumn("dbo.Employees", "Position", c => c.String());
            DropForeignKey("dbo.PaintingMovementJournals", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PaintingMovements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Id", "dbo.Users");
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Employees", "PositionId");
            DropTable("dbo.Users");
            DropTable("dbo.Positions");
            AddPrimaryKey("dbo.Employees", "Id");
            AddForeignKey("dbo.PaintingMovementJournals", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaintingMovements", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}

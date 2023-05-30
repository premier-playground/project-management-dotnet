namespace ProjectManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Field = c.String(),
                        Degree = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentProjectAssociations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Level = c.Int(nullable: false),
                        AddedAt = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Institution = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professors", "Id", "dbo.Projects");
            DropForeignKey("dbo.StudentProjectAssociations", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.StudentProjectAssociations", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Id", "dbo.Projects");
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.StudentProjectAssociations", new[] { "Project_Id" });
            DropIndex("dbo.StudentProjectAssociations", new[] { "Student_Id" });
            DropIndex("dbo.Professors", new[] { "Id" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentProjectAssociations");
            DropTable("dbo.Projects");
            DropTable("dbo.Professors");
        }
    }
}

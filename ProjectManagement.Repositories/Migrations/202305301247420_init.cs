namespace ProjectManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Id", "dbo.Projects");
            DropForeignKey("dbo.Professors", "Id", "dbo.Projects");
            DropIndex("dbo.Professors", new[] { "Id" });
            DropIndex("dbo.Students", new[] { "Id" });
            AddColumn("dbo.Projects", "Coordinator_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Coordinator_Id");
            AddForeignKey("dbo.Projects", "Coordinator_Id", "dbo.Professors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Coordinator_Id", "dbo.Professors");
            DropIndex("dbo.Projects", new[] { "Coordinator_Id" });
            DropColumn("dbo.Projects", "Coordinator_Id");
            CreateIndex("dbo.Students", "Id");
            CreateIndex("dbo.Professors", "Id");
            AddForeignKey("dbo.Professors", "Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Students", "Id", "dbo.Projects", "Id");
        }
    }
}

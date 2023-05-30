namespace ProjectManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pending_changes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Discriminator", newName: "Type");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Type", newName: "Discriminator");
        }
    }
}

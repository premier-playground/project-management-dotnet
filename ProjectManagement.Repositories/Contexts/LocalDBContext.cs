using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repositories.Contexts
{
    public class LocalDBContext : IdentityDbContext<User>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }

        public LocalDBContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<LocalDBContext>(new ProjectManagementInitializer());
            var roleStore = new RoleStore<IdentityRole>(this);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            roleManager.Create(new IdentityRole("PROFESSOR"));
            roleManager.Create(new IdentityRole("STUDENT"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Map<Student>(m => m.Requires("Type").HasValue("Student"))
                .Map<Professor>(m => m.Requires("Type").HasValue("Professor"));
        }


    }

    public class ProjectManagementInitializer : CreateDatabaseIfNotExists<LocalDBContext>
    {
    }
}

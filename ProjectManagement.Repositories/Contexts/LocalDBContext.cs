using System.Data.Entity;
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

        public LocalDBContext(): base("name=DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Map<Student>(m => m.Requires("Type").HasValue("Student"))
                .Map<Professor>(m => m.Requires("Type").HasValue("Professor"));
        }
    }
}

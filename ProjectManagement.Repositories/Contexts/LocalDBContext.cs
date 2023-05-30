using System.Data.Entity;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repositories.Contexts
{
    public class LocalDBContext: DbContext
    {
        public System.Data.Entity.DbSet<Project> Projects { get; set; }
        public System.Data.Entity.DbSet<Student> Students { get; set; }
        public System.Data.Entity.DbSet<Professor> Professors { get; set; }
    }
}

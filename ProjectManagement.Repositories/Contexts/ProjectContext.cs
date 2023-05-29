using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repositories.Contexts
{
    public class ProjectContext: DbContext
    {
        public DbSet<Project> Projects { get; set; }
    }
}

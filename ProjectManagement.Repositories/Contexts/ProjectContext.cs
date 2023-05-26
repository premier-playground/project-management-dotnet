using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ProjectManagement.Repositories.Contexts
{
    public class ProjectContext: DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

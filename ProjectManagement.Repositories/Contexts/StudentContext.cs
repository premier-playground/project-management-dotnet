using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Configuration;

namespace ProjectManagement.Repositories.Contexts
{
    public class StudentContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}

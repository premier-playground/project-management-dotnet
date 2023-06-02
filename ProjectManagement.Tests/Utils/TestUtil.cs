using ProjectManagement.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Utils
{
    internal class TestUtil
    {
        public static void CleanDatabase()
        {
            using (var localDbContext = new LocalDBContext())
            {
                localDbContext.StudentProjectAssociations.RemoveRange(localDbContext.StudentProjectAssociations);
                localDbContext.Professors.RemoveRange(localDbContext.Professors);
                localDbContext.Students.RemoveRange(localDbContext.Students);
                localDbContext.Projects.RemoveRange(localDbContext.Projects);
                localDbContext.SaveChanges();
            }
        }
    }
}

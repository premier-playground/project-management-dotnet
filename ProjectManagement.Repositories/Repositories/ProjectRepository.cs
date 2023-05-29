using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;

namespace ProjectManagement.Repositories.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly DbContext _context;

        public ProjectRepository(DbContext context)
        {
            this._context = context;
        }

        public Project InsertProject(Project project)
        {
            Project newProject = null;

            using (var localDbContext = (LocalDBContext)_context)
            {
                newProject = localDbContext.Projects.Add(project);
                localDbContext.SaveChanges();
            }

            return newProject;
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

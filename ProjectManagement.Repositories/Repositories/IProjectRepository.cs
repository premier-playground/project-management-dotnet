using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Repositories.Repositories
{
    public interface IProjectRepository: IDisposable
    {
        Project InsertProject(Project project);
        Project UpdateProject(Project project, int projectId);
        void DeleteProject(Project project);
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
    }
}

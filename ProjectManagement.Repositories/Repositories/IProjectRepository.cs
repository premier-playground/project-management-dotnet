using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repositories.Repositories
{
    public interface IProjectRepository: IDisposable
    {

        Project InsertProject(Project project);
        void UpdateProject(Project project);
        void DeleteStudent(Project project);
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(string id);
    }
}

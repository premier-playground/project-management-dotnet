using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Services
{
    public interface IProjectService
    {
        Project CreateProject(ProjectDTO projectDto);
        Project AddStudentToProject(StudentProjectAssociationDTO studentProjectAssociationDTO, int projectId);
        Project RemoveStudentFromProject(string studentId, int projectId);
        Project UpdateProject(ProjectDTO projectDto, int projectId);
        void DeleteProject(int projectId);
        List<ProjectGetDTO> GetProjects();
        ProjectGetDTO GetProjectById(int id);
    }
}

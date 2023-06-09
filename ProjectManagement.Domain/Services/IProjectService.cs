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
        ReturnProjectDTO CreateProject(ProjectDTO projectDto);
        ReturnProjectDTO AddStudentToProject(StudentProjectAssociationDTO studentProjectAssociationDTO, int projectId);
        ReturnProjectDTO RemoveStudentFromProject(string studentId, int projectId);
        ReturnProjectDTO UpdateProject(ProjectDTO projectDto, int projectId);
        void DeleteProject(int projectId);
        List<ReturnProjectDTO> GetProjects();
        ReturnProjectDTO GetProjectById(int id);
    }
}

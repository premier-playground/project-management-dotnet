using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
using ProjectManagement.Domain.Mappers;
using ProjectManagement.Repositories.Repositories;

namespace ProjectManagement.Domain.Services
{
    public class ProjectService
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;
        private ProjectMapper _mapper;

        public ProjectService(DbContext locaDbContext)
        {
            _projectRepository = new ProjectRepository(locaDbContext);
            _userRepository = new UserRepository(locaDbContext);
            _mapper = new ProjectMapper();
        }

        public Project CreateProject(ProjectDTO projectDto)
        {
            Project newProject = null;

            Professor professor = _userRepository.GetProfessorById(projectDto.CoordinatorId);
            if (professor != null)
            {
                Project project = new Project(projectDto.Name, projectDto.Description, professor);
                newProject = _projectRepository.InsertProject(project);
            }

            return newProject;
        }


        public Project AddStudentToProject(StudentProjectAssociationDTO studentProjectAssociationDTO, int projectId)
        {
            Project project = _projectRepository.GetProjectById(projectId);

            project = _projectRepository.AddStudent(project.Id, studentProjectAssociationDTO.StudentId,
                studentProjectAssociationDTO.Level);

            return project;
        }

        public Project RemoveStudentFromProject(string studentId, int projectId)
        {
            var project = _projectRepository.RemoveStudent(projectId, studentId);

            return project;
        }

        public Project UpdateProject(ProjectDTO projectDto, int projectId)
        {
            Professor coordinator = _userRepository.GetProfessorById(projectDto.CoordinatorId);
            Project project = new Project(projectDto.Name, projectDto.Description, coordinator);
            project = _projectRepository.UpdateProject(project, projectId);
            return project;
        }

        public void DeleteProject(int projectId)
        {
            _projectRepository.DeleteProject(projectId);
        }
    }
}

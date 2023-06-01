using ProjectManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
using ProjectManagement.Domain.Mappers;

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

        public Project GetProjectById(int id)
        {       
            return this._projectRepository.GetProjectById(id);
        }
        public IEnumerable<Project> GetAllProjects()
        {
            return this._projectRepository.GetAllProjects();
        }

        public ProjectDTO AddStudentToProject(StudentProjectAssociationDTO studentProjectAssociationDTO, int projectId)
        {
            Student student = this._userRepository.GetStudentById(studentProjectAssociationDTO.StudentId);

            StudentProjectAssociation studentProjectAssociation = new StudentProjectAssociation(
                student , studentProjectAssociationDTO.Level, studentProjectAssociationDTO.AddedAt
            );

            Project project = this._projectRepository.GetProjectById(projectId);

            project.StudentProjectAssociations.Add(studentProjectAssociation);

            this._projectRepository.UpdateProject(project);

            return this._mapper.MapToProjectDTO(project);
        }
    }
}

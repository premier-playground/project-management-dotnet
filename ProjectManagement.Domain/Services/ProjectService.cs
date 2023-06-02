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
        private CustomMapper _mapper;

        public ProjectService(DbContext locaDbContext)
        {
            _projectRepository = new ProjectRepository(locaDbContext);
            _userRepository = new UserRepository(locaDbContext);
            _mapper = new CustomMapper();
        }

        public ReturnProjectDTO CreateProject(ProjectDTO projectDto)
        {
            Project newProject = null;

            Professor professor = _userRepository.GetProfessorById(projectDto.CoordinatorId);

            if (professor != null)
            {
                Project project = new Project(projectDto.Name, projectDto.Description, professor);
                newProject = _projectRepository.InsertProject(project);
            }

            ReturnProjectDTO returnProject = this._mapper.Map<Project, ReturnProjectDTO>(newProject);

            return returnProject;
        }


        public ReturnProjectDTO AddStudentToProject(StudentProjectAssociationDTO studentProjectAssociationDTO, int projectId)
        {
            var project = this._projectRepository.AddStudent(
                projectId, 
                studentProjectAssociationDTO.StudentId,
                studentProjectAssociationDTO.Level
            );

            return this._mapper.Map<Project, ReturnProjectDTO>(project);
        }


        public ReturnProjectDTO UpdateProject(ProjectDTO projectDto, int projectId)
        {
            Professor coordinator = _userRepository.GetProfessorById(projectDto.CoordinatorId);

            Project project = new Project(projectDto.Name, projectDto.Description, coordinator);

            project = _projectRepository.UpdateProject(project, projectId);

            return this._mapper.Map<Project, ReturnProjectDTO>(project);
        }
    }
}

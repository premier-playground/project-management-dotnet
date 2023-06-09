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
    public class ProjectService: IProjectService
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
            Project project = _projectRepository.GetProjectById(projectId);

            project = _projectRepository.AddStudent(
                project.Id, 
                studentProjectAssociationDTO.StudentId,
                studentProjectAssociationDTO.Level
            );

            return _mapper.Map<Project, ReturnProjectDTO>(project);
        }

        public ReturnProjectDTO RemoveStudentFromProject(string studentId, int projectId)
        {
            var project = _projectRepository.RemoveStudent(projectId, studentId);

            return _mapper.Map<Project, ReturnProjectDTO>(project);
        }


        public ReturnProjectDTO UpdateProject(ProjectDTO projectDto, int projectId)
        {
            Professor coordinator = _userRepository.GetProfessorById(projectDto.CoordinatorId);
            if (coordinator == null) { return GetProjectById(projectId); };

            Project project = new Project(projectDto.Name, projectDto.Description, coordinator);
            project = _projectRepository.UpdateProject(project, projectId);
            return this._mapper.Map<Project, ReturnProjectDTO>(project);
        }

        public void DeleteProject(int projectId)
        {
            _projectRepository.DeleteProject(projectId);
        }

        public List<ReturnProjectDTO> GetProjects()
        {
            return _projectRepository.GetAllProjects()
                .Select(p => _mapper.Map<Project, ReturnProjectDTO>(p))
                .ToList();
        }

        public ReturnProjectDTO GetProjectById(int id)
        {
            Project p = _projectRepository.GetProjectById(id);
            if (p == null) return null;
            return _mapper.Map<Project, ReturnProjectDTO>(p);
        }
    }
}

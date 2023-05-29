using ProjectManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Domain.Services
{
    public class ProjectService
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;

        public ProjectService(DbContext locaDbContext)
        {
            _projectRepository = new ProjectRepository(locaDbContext);
            _userRepository = new UserRepository(locaDbContext);
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
    }
}

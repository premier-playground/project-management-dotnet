using ProjectManagement.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Repositories.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Tests.Utils;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Tests.ServicesTest
{
    [TestClass]
    public class ProjectServiceTest
    {
        private readonly UserService _userService;
        private readonly ProjectService _projectService;

        public ProjectServiceTest()
        {
            _userService = new UserService(new LocalDBContext());
            _projectService = new ProjectService(new LocalDBContext());
        }

        [TestCleanup()]
        public void Cleanup()
        {
            TestUtil.CleanDatabase();
        }

        [TestMethod]
        public void SuccessfulCreateProject()
        {
            var professor = _userService.CreateProfessor(new ProfessorDTO
            {
                Name = "ProfessorX",
                Email = "professor_x@xmen.com",
                Password = "123456",
                Role = Role.PROFESSOR,
                Degree = "Psychiatry",
                Field = "Mind Reading"
            });
            Assert.IsNotNull(professor);

            ProjectDTO projectDTO = new ProjectDTO
            {
                Name = "Project 1",
                Description = "Description 1",
                CoordinatorId = professor.Id
            };
            var project = _projectService.CreateProject(projectDTO);
            Assert.IsNotNull(project.Coordinator);
            Assert.IsNotNull(project);
        }

        [TestMethod]
        public void UnsuccessfulCreateProject()
        {
            ProjectDTO projectDTO = new ProjectDTO
            {
                Name = "Project 1",
                Description = "Description 1",
                CoordinatorId = new Guid().ToString()
            };
            var project = _projectService.CreateProject(projectDTO);
            Assert.IsNull(project);
        }

        [TestMethod]
        public void SuccessfulAddStudentToProject()
        {
            var professor = _userService.CreateProfessor(new ProfessorDTO
            {
                Name = "ProfessorX",
                Email = "professor_x@xmen.com",
                Password = "123456",
                Role = Role.PROFESSOR,
                Degree = "Psychiatry",
                Field = "Mind Reading"
            });
            Assert.IsNotNull(professor);

            var createdStudent = _userService.CreateStudent(new StudentDTO
            {
                Email = "davi.sousa@ccc.ufcg.edu.br",
                Name = "Davi",
                Password = "123456",
                Role = Role.STUDENT,
                Institution = "UFCG"
            });
            Assert.IsNotNull(createdStudent);

            ProjectDTO projectDTO = new ProjectDTO
            {
                Name = "Project 1",
                Description = "Description 1",
                CoordinatorId = professor.Id
            };
            var project = _projectService.CreateProject(projectDTO);
            Assert.IsNotNull(projectDTO);

            project = _projectService.AddStudentToProject(new StudentProjectAssociationDTO
            {
                StudentId = createdStudent.Id,
                Level = Level.JUNIOR
            }, project.Id);
            Assert.IsNotNull(project);
            Assert.IsTrue(project.StudentProjectAssociations.Any());
        }
    }
}

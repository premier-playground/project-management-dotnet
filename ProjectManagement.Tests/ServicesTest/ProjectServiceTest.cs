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
using ProjectManagement.Entities.Models;

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

        public Professor CreateProfessor()
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
            return professor;
        }

        public Student CreateStudent()
        {
            return _userService.CreateStudent(new StudentDTO
            {
                Email = "davi.sousa@ccc.ufcg.edu.br",
                Name = "Davi",
                Password = "123456",
                Role = Role.STUDENT,
                Institution = "UFCG"
            });
        }

        public Project CreateProject(Professor professor)
        {
            ProjectDTO projectDTO = new ProjectDTO
            {
                Name = "Project 1",
                Description = "Description 1",
                CoordinatorId = professor.Id
            };

            return _projectService.CreateProject(projectDTO);
        } 

        [TestMethod]
        public void SuccessfulCreateProject()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var project = CreateProject(professor);
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
        public void SuccessfulUpdateProject()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            var updatedProject = _projectService.UpdateProject(new ProjectDTO
            {
                Name = "updated project",
                Description = project.Description,
                CoordinatorId = project.Coordinator.Id
            }, project.Id);
            Assert.IsNotNull(updatedProject);
            Assert.IsTrue(updatedProject.Name.Equals("updated project"));
        }

        [TestMethod]
        public void UnsuccessfulUpdateProject()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            var updatedProject = _projectService.UpdateProject(new ProjectDTO
            {
                Name = "updated project",
                Description = project.Description,
                CoordinatorId = new Guid().ToString()
            }, project.Id);
            Assert.IsNotNull(updatedProject);
            Assert.IsTrue(updatedProject.Name.Equals(project.Name));
        }

        [TestMethod]
        public void SuccessfulAddStudentToProject()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var createdStudent = CreateStudent();
            Assert.IsNotNull(createdStudent);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            project = _projectService.AddStudentToProject(new StudentProjectAssociationDTO
            {
                StudentId = createdStudent.Id,
                Level = Level.JUNIOR
            }, project.Id);

            Assert.IsNotNull(project);
            Assert.IsTrue(project.StudentProjectAssociations.Any());
        }

        [TestMethod]
        public void UnsuccessfulAddStudentToProject()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var createdStudent = CreateStudent();
            Assert.IsNotNull(createdStudent);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            project = _projectService.AddStudentToProject(new StudentProjectAssociationDTO
            {
                StudentId = "123456",
                Level = Level.JUNIOR
            }, project.Id);
            Assert.IsNull(project);
        }

        [TestMethod]
        public void SuccessfulRemoveStudentToProject()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var createdStudent = CreateStudent();
            Assert.IsNotNull(createdStudent);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            project = _projectService.AddStudentToProject(new StudentProjectAssociationDTO
            {
                StudentId = createdStudent.Id,
                Level = Level.JUNIOR
            }, project.Id);

            Assert.IsNotNull(project);
            Assert.IsTrue(project.StudentProjectAssociations.Any());

            var studentsAssociationSize = project.StudentProjectAssociations.Count;
            project = _projectService.RemoveStudentFromProject(createdStudent.Id, project.Id);
            Assert.IsNotNull(project);
            Assert.IsTrue(project.StudentProjectAssociations.Count < studentsAssociationSize);
        }

        [TestMethod]
        public void UnsuccessfulRemoveStudentToProject()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var createdStudent = CreateStudent();
            Assert.IsNotNull(createdStudent);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            project = _projectService.RemoveStudentFromProject(createdStudent.Id, project.Id);
            Assert.IsNull(project);
        }

        [TestMethod]
        public void SuccessfulGetProjectById()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            var getProject = _projectService.GetProjectById(project.Id);
            Assert.IsNotNull(getProject);
        }

        [TestMethod]
        public void UnsuccessfulGetProjectById()
        {
            var getProject = _projectService.GetProjectById(9999);
            Assert.IsNull(getProject);
        }

        [TestMethod]
        public void SuccessfulGetProjectsNotEmpty()
        {
            var professor = CreateProfessor();
            Assert.IsNotNull(professor);

            var project = CreateProject(professor);
            Assert.IsNotNull(project);

            var projects = _projectService.GetProjects();
            Assert.IsTrue(projects.Count > 0);
        }

        [TestMethod]
        public void SuccessfulGetProjectsEmpty()
        {
            var projects = _projectService.GetProjects();
            Assert.IsTrue(projects.Count == 0);
        }
    }
}

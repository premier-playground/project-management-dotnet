using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Domain.Services;
using ProjectManagement.Entities.Enums;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Tests.Utils;

namespace ProjectManagement.Tests.ServicesTest
{
    [TestClass]
    public class UserServiceTest
    {
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _userService = new UserService(new LocalDBContext());
        }

        [TestCleanup()]
        public void Cleanup()
        {
            TestUtil.CleanDatabase();
        }

        public Student CreateStudent()
        {
            StudentDTO studentDTO = new StudentDTO
            {
                Email = "davi.sousa@ccc.ufcg.edu.br",
                Name = "Davi",
                Password = "123456",
                Role = Role.STUDENT,
                Institution = "UFCG"
            };
            return _userService.CreateStudent(studentDTO);
        }

        public Professor CreateProfessor()
        {
            ProfessorDTO professorDto = new ProfessorDTO
            {
                Name = "ProfessorX",
                Email = "professor_x@xmen.com",
                Password = "123456",
                Role = Role.PROFESSOR,
                Degree = "Psychiatry",
                Field = "Mind Reading"
            };
            return _userService.CreateProfessor(professorDto);
        }

        [TestMethod]
        public void SuccessfulCreateStudent()
        {
            var createdStudent = CreateStudent();
            Assert.IsNotNull(createdStudent);
        }

        [TestMethod]
        public void UnsuccessfulCreateStudent()
        {
            var student = CreateStudent();
            Assert.IsNotNull(student);
            Assert.IsNull(CreateStudent());
        }

        [TestMethod]
        public void SuccessfulCreateProfessor()
        {
            var createdProfessor = CreateProfessor();
            Assert.IsNotNull(createdProfessor);
        }

        [TestMethod]
        public void UnsuccessfulCreateProfessor()
        {
            var createdProfessor = CreateProfessor();
            Assert.IsNotNull(createdProfessor);
            Assert.IsNull(CreateProfessor());
        }

        [TestMethod]
        public void SuccessfulGetStudentById()
        {
            var createdStudent = CreateStudent();
            Assert.IsNotNull(createdStudent);
            var getStudent = _userService.GetStudentById(createdStudent.Id);
            Assert.IsNotNull(getStudent);
        }

        [TestMethod]
        public void UnsuccessfulGetStudentById()
        {
            var getStudent = _userService.GetStudentById(new Guid().ToString());
            Assert.IsNull(getStudent);
        }

        [TestMethod]
        public void SuccessfulGetProfessorById()
        {
            var createdProfessor = CreateProfessor();
            Assert.IsNotNull(createdProfessor);
            var getProfessor = _userService.GetProfessorById(createdProfessor.Id);
            Assert.IsNotNull(getProfessor);
        }

        [TestMethod]
        public void UnsuccessfulGetProfessorById()
        {
            var getProfessor = _userService.GetProfessorById(new Guid().ToString());
            Assert.IsNull(getProfessor);
        }

        [TestMethod]
        public void SuccessfulGetStudentsNotEmpty()
        {
            var createdStudent = CreateStudent();
            Assert.IsNotNull(createdStudent);
            var students = _userService.GetStudents();
            Assert.IsTrue(students.Count > 0);
        }

        [TestMethod]
        public void SuccessfulGetStudentsEmpty()
        {
            var students = _userService.GetStudents();
            Assert.IsTrue(students.Count == 0);
        }

        [TestMethod]
        public void SuccessfulGetProfessorsNotEmpty()
        {
            var createdProfessor = CreateProfessor();
            Assert.IsNotNull(createdProfessor);
            var professors = _userService.GetProfessors();
            Assert.IsTrue(professors.Count > 0);
        }

        [TestMethod]
        public void SuccessfulGetProfessorsEmpty()
        {
            var professors = _userService.GetProfessors();
            Assert.IsTrue(professors.Count == 0);
        }
    }
}

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
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _userService = new UserService(new LocalDBContext());
        }

        [TestCleanup()]
        public void Cleanup()
        {
            TestUtil.CleanDatabase();
        }

        [TestMethod]
        public void SuccessfulCreateStudent()
        {
            StudentDTO studentDTO = new StudentDTO
            {
                Email = "davi.sousa@ccc.ufcg.edu.br",
                Name = "Davi", 
                Password = "123456",
                Role = Role.STUDENT, 
                Institution = "UFCG"
            };

            var createdStudent = _userService.CreateStudent(studentDTO);
            Assert.IsNotNull(createdStudent);
        }

        [TestMethod]
        public void UnsuccessfulCreateStudent()
        {
            StudentDTO studentDTO = new StudentDTO
            {
                Email = "davi.sousa@ccc.ufcg.edu.br",
                Name = "Davi",
                Password = "123456",
                Role = Role.STUDENT,
                Institution = "UFCG"
            };
            Assert.IsNotNull(_userService.CreateStudent(studentDTO));
            Assert.IsNull(_userService.CreateStudent(studentDTO));
        }

        [TestMethod]
        public void SuccessfulCreateProfessor()
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
            var createdProfessor = _userService.CreateProfessor(professorDto);
            Assert.IsNotNull(createdProfessor);
        }

        [TestMethod]
        public void UnsuccessfulCreateProfessor()
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
            var createdProfessor = _userService.CreateProfessor(professorDto);
            Assert.IsNotNull(createdProfessor);
            Assert.IsNull(_userService.CreateProfessor(professorDto));
        }
    }
}

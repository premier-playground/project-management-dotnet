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

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            using (var localDbContext = new LocalDBContext())
            {
                localDbContext.StudentProjectAssociations.RemoveRange(localDbContext.StudentProjectAssociations);
                localDbContext.Professors.RemoveRange(localDbContext.Professors);
                localDbContext.Students.RemoveRange(localDbContext.Students);
                localDbContext.Projects.RemoveRange(localDbContext.Projects);
            }
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
            Assert.IsTrue(createdStudent.UserName == studentDTO.Name);
        }
    }
}

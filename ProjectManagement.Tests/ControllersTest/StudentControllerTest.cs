using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Domain.Services;
using ProjectManagement.Web.Controllers;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProjectManagement.Tests.ControllersTest
{
    [TestClass]
    public class StudentControllerTest
    {
        private StudentController studentController;
        private Mock<IUserService> mockUserService;
        private Mock<StudentDTO> mockStudentDTO;
        private Mock<ReturnStudentDTO> mockReturnStudentDTO;


        [TestInitialize]
        public void Initialize()
        {
            mockUserService = new Mock<IUserService>();
            mockStudentDTO = new Mock<StudentDTO>();
            mockStudentDTO.SetupAllProperties();
            mockStudentDTO.Object.UserName = "Test User";
            mockStudentDTO.Object.Email = "test.user@email.com";
            mockStudentDTO.Object.Institution = "UFCG";
            mockStudentDTO.Object.Password = "123456";

            mockReturnStudentDTO = new Mock<ReturnStudentDTO>();
            mockReturnStudentDTO.SetupAllProperties();
            mockReturnStudentDTO.Object.Id = new Guid().ToString();
            mockReturnStudentDTO.Object.UserName = "Test User";
            mockReturnStudentDTO.Object.Email = "test.user@email.com";
            mockReturnStudentDTO.Object.Institution = "UFCG";

            studentController = new StudentController(mockUserService.Object);
        }

        [TestMethod]
        public void SuccessfulCreateStudent()
        {
            // setup
            mockUserService
            .Setup(u => u.CreateStudent(mockStudentDTO.Object))
            .Returns(mockReturnStudentDTO.Object);

            // act
            var result = studentController.CreateStudent(mockStudentDTO.Object) as OkNegotiatedContentResult<ReturnStudentDTO>;

            // assert
            mockUserService.Verify(u => u.CreateStudent(mockStudentDTO.Object), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, mockReturnStudentDTO.Object);
        }

        [TestMethod]
        public void UnsuccessfulCreateStudent()
        {
            // setup
            mockUserService
                .SetupSequence(u => u.CreateStudent(mockStudentDTO.Object))
                .Returns(mockReturnStudentDTO.Object)
                .Returns(null as ReturnStudentDTO);

            // act
            var result = studentController.CreateStudent(mockStudentDTO.Object) as OkNegotiatedContentResult<ReturnStudentDTO>;
            result = studentController.CreateStudent(mockStudentDTO.Object) as OkNegotiatedContentResult<ReturnStudentDTO>;

            // assert
            mockUserService.Verify(u => u.CreateStudent(mockStudentDTO.Object), Times.Exactly(2));
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, null);
        }

    }
}

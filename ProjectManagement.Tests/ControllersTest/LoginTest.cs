using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Domain.Services;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Tests.Utils;
using ProjectManagement.Web;

namespace ProjectManagement.Tests.ControllersTest
{
    [TestClass]
    public class LoginTest
    {
        private IUserService _userService;

        [TestInitialize]
        public void Initialize()
        {
            _userService = new UserService(new LocalDBContext());

        }

        [TestCleanup]
        public void Cleanup()
        {
            TestUtil.CleanDatabase();
        }

        [TestMethod]
        public void SuccessfulLogin()
        {
            var studentDto = new StudentDTO
            {
                Email = "davi.sousa@ccc.ufcg.edu.br",
                UserName = "davibss",
                Password = "123456",
                Institution = "UFCG"
            };
            var createdStudent = _userService.CreateStudent(studentDto);

            using (var server = TestServer.Create<Startup>())
            {
                var response = server.HttpClient
                    .PostAsync("/token", 
                        new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("username", studentDto.UserName),
                            new KeyValuePair<string, string>("password", studentDto.Password),
                            new KeyValuePair<string, string>("grant_type", "password")
                        })
                    );
                var task = Task.Run(async () => await response);
                var result = task.Result;

                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            }
        }

        [TestMethod]
        public void UnsuccessfulLogin()
        {
            var studentDto = new StudentDTO
            {
                Email = "davi.sousa@ccc.ufcg.edu.br",
                UserName = "davibss",
                Password = "123456",
                Institution = "UFCG"
            };
            var createdStudent = _userService.CreateStudent(studentDto);

            using (var server = TestServer.Create<Startup>())
            {
                var response = server.HttpClient
                    .PostAsync("/token",
                        new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("username", studentDto.UserName),
                            new KeyValuePair<string, string>("password", studentDto.Password.Reverse().ToString()),
                            new KeyValuePair<string, string>("grant_type", "password")
                        })
                    );
                var task = Task.Run(async () => await response);
                var result = task.Result;

                Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            }
        }
    }
}

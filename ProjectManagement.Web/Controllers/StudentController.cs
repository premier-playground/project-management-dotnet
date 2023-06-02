using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ProjectManagement.Domain.Services;
using ProjectManagement.Entities.Enums;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Repositories.Repositories;
using ProjectManagement.Domain.DTO;

namespace ProjectManagement.Web.Controllers
{
    public class StudentController: ApiController
    {
        private readonly UserService _userService;

        public StudentController ()
        {
            this._userService = new UserService(new LocalDBContext());
        }


        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult CreateStudent(StudentDTO studentDto)
        {
            IHttpActionResult httpActionResult;
            try
            {
                ReturnStudentDTO student = _userService.CreateStudent(studentDto);
                httpActionResult = Ok(student);
            }
            catch (Exception)
            {
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }
    }
}
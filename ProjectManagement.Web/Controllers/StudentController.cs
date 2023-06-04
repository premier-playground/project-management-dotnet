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
                Student student = _userService.CreateStudent(studentDto);
                httpActionResult = Ok(student);
            }
            catch (Exception e)
            {
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetStudents()
        {
            var students = _userService.GetStudents();
            return Ok(students);
        }

        [Route("api/student/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetStudentById(string id)
        {
            var student = _userService.GetStudentById(id); 
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(StudentDTO studentDto)
        {
            IHttpActionResult httpActionResult;
            try
            {
                _userService.UpdateStudent(studentDto);
                httpActionResult = Ok(studentDto);
            }
            catch (Exception e)
            {
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }

        [HttpDelete]
        public IHttpActionResult DeleteStudent(string id)
        {
            IHttpActionResult httpActionResult;
            try
            {
                _userService.DeleteStudent(id);
                httpActionResult = Ok();
            }
            catch (Exception e)
            {
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }
    }
}
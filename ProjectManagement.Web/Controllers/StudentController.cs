﻿using System;
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
        public IHttpActionResult GetAllStudents()
        {
            IHttpActionResult httpActionResult;
            try
            {
                IEnumerable<Student> projects = _userService.GetAllStudents();
                httpActionResult = Ok(projects);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }
    }
}
   
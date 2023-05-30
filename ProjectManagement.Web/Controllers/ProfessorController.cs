using ProjectManagement.Domain.DTO;
using ProjectManagement.Domain.Services;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProjectManagement.Web.Controllers
{
    public class ProfessorController: ApiController
    {
        private readonly UserService _userService;

        public ProfessorController()
        {
            this._userService = new UserService(new LocalDBContext());
        }

        [HttpPost]
        public IHttpActionResult CreateProfessor(ProfessorDTO professorDto)
        {
            IHttpActionResult httpActionResult;
            try
            {
                Professor professor = _userService.CreateProfessor(professorDto);
                httpActionResult = Ok(professor);
            }
            catch (Exception e)
            {
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }

        [HttpGet]
        public IHttpActionResult GetAllProfessors()
        {
            IHttpActionResult httpActionResult;
            try
            {
                IEnumerable<Professor> projects = _userService.GetAllProfessors();
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
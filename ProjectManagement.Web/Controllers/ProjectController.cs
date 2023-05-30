using ProjectManagement.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Web.Controllers
{
    public class ProjectController: ApiController
    {
        private readonly ProjectService _userService;

        public ProjectController()
        {
            _userService = new ProjectService(new LocalDBContext());
        }

        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDTO projectDTO)
        {
            IHttpActionResult httpActionResult;
            try
            {
                Project project = _userService.CreateProject(projectDTO);
                if (project == null)
                {
                    httpActionResult = NotFound();
                }
                else
                {
                    httpActionResult = Ok(project);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }


        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult addStudentToProject([FromBody] StudentProjectAssociationDTO studentProjectAssociation, int id)
        {
            

            return Ok(studentProjectAssociation);
        }
    }
}
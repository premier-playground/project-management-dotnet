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
        private readonly ProjectService _projectService;

        public ProjectController()
        {
            _projectService = new ProjectService(new LocalDBContext());
        }

        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDTO projectDTO)
        {
            IHttpActionResult httpActionResult;
            try
            {
                Project project = _projectService.CreateProject(projectDTO);
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

        [HttpGet]
        public IHttpActionResult GetAllProjects()
        {
            IHttpActionResult httpActionResult;
            try
            {
                IEnumerable<Project> projects = _projectService.GetAllProjects();
                httpActionResult = Ok(projects);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }

        [Route("project/{id}")]
        [HttpPost]
        public IHttpActionResult addStudentToProject([FromBody] StudentProjectAssociationDTO studentProjectAssociation, int id)
        {
            ProjectDTO result = this._projectService.AddStudentToProject(studentProjectAssociation, id);

            return Ok(result);
        }
    }
}
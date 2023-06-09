using ProjectManagement.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
using System.Web.Http;

namespace ProjectManagement.Web.Controllers
{
    public class ProjectController: ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController()
        {
            _projectService = new ProjectService(new LocalDBContext());
        }


        [HttpPost]
        [FilterConfig.ProfessorClaimsAuthorize]
        public IHttpActionResult CreateProject(ProjectDTO projectDTO)
        {
            IHttpActionResult httpActionResult;
            try
            {
                ReturnProjectDTO project = _projectService.CreateProject(projectDTO);
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
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }


        [Route("api/project/{id}/addStudent")]
        [HttpPost]
        [FilterConfig.ProfessorClaimsAuthorize]
        [FilterConfig.ProjectAuthorize]
        public IHttpActionResult AddStudentToProject([FromBody] StudentProjectAssociationDTO studentProjectAssociation, int id)
        {
            try
            {
                ReturnProjectDTO project = this._projectService.AddStudentToProject(studentProjectAssociation, id);
                return Ok(project);
            }
            catch
            {
                return BadRequest("Can't add this student to this project");
            }
        }

        [Route("api/project/{id}/removeStudent")]
        [HttpPost]
        [FilterConfig.ProfessorClaimsAuthorize]
        [FilterConfig.ProjectAuthorize]
        public IHttpActionResult RemoveStudentToProject([FromBody] StudentProjectAssociationDTO studentProjectAssociation, int id)
        {
            try
            {
                var project = this._projectService.RemoveStudentFromProject(studentProjectAssociation.StudentId, id);
                return Ok(project);
            }
            catch
            {
                return BadRequest("Can't remove this student to this project");
            }

        }


        [Route("api/project/{id}")]
        [HttpPatch]
        [FilterConfig.ProjectAuthorize]
        public IHttpActionResult UpdateProject(ProjectDTO projectDTO, int id)
        {
            ReturnProjectDTO project = _projectService.UpdateProject(projectDTO, id);
            
            return Ok(project);
        }

        [Route("api/project/{id}")]
        [HttpDelete]
        [FilterConfig.ProjectAuthorize]
        public IHttpActionResult DeleteProject(int id)
        {
            try
            {
                _projectService.DeleteProject(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetProjects()
        {
            var projects = _projectService.GetProjects();
            return Ok(projects);
        }

        [Route("api/project/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            return Ok(project);
        }
    }
}
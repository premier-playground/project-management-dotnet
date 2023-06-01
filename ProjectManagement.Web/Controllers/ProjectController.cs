using ProjectManagement.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
        [FilterConfig.ProfessorClaimsAuthorize]
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
                    httpActionResult = Ok(new
                    {
                        project.Id,
                        project.Name,
                        project.Description,
                        Coordinator = new
                        {
                            project.Coordinator.Id,
                            project.Coordinator.UserName,
                            project.Coordinator.Email,
                            project.Coordinator.Degree,
                            project.Coordinator.Field
                        }
                    });
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                httpActionResult = BadRequest();
            }

            return httpActionResult;
        }


        [Route("api/project/{id}/addStudent")]
        [HttpPost]
        [FilterConfig.ProfessorClaimsAuthorize]
        public IHttpActionResult addStudentToProject([FromBody] StudentProjectAssociationDTO studentProjectAssociation, int id)
        {
            Project project = this._projectService.AddStudentToProject(studentProjectAssociation, id);

            var studentsAssociation = project.StudentProjectAssociations.Select(sta => new
            {
                sta.Id,
                sta.Level,
                sta.AddedAt,
                Student = new
                {
                    sta.Student.Id,
                    sta.Student.UserName,
                    sta.Student.Email,
                    sta.Student.Institution
                }
            }).ToList();

            return Ok(new {
                project.Id,
                project.Name,
                project.Description,
                Coordinator = new
                    {
                        project.Coordinator.Id,
                        project.Coordinator.UserName,
                        project.Coordinator.Email,
                        project.Coordinator.Degree,
                        project.Coordinator.Field
                    },  
                StudentsAssociations = studentsAssociation
            });
        }

        [Route("api/project/{id}")]
        [HttpPatch]
        public IHttpActionResult UpdateProject(ProjectDTO projectDTO, int id)
        {
            Project project = _projectService.UpdateProject(projectDTO, id);
            return Ok(new
            {
                project.Id,
                project.Name,
                project.Description,
                Coordinator = new
                {
                    project.Coordinator.Id,
                    project.Coordinator.UserName,
                    project.Coordinator.Email,
                    project.Coordinator.Degree,
                    project.Coordinator.Field
                }
            });
        }
    }
}
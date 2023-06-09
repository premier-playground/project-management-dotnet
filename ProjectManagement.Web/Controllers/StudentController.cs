using System;
using System.Web.Http;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Domain.Services;
using ProjectManagement.Repositories.Contexts;

namespace ProjectManagement.Web.Controllers
{
    public class StudentController : ApiController
     {
         private readonly IUserService _userService;

         public StudentController()
         {
             this._userService = new UserService(new LocalDBContext());
         }
         public StudentController(IUserService userService)
         {
             this._userService = userService;
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

         [Route("api/student/{id}")]
         [HttpPut]
         public IHttpActionResult UpdateStudent(StudentDTO studentDto, string id)
         {
             IHttpActionResult httpActionResult;
             try
             {
                 _userService.UpdateStudent(studentDto, id);
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
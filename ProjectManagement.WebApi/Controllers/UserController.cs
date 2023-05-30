using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Domain.Services;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;


namespace ProjectManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;

        public UserController ()
        {
            this._userService = new UserService(new LocalDBContext());
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentDTO studentDto)
        {
            IActionResult httpActionResult;
            try
            {
                Student student = _userService.CreateStudent(studentDto);
                httpActionResult = new OkObjectResult(student);
            }
            catch (Exception)
            {
                httpActionResult = BadRequest();
            }
            
            return httpActionResult;
        }

    }
}
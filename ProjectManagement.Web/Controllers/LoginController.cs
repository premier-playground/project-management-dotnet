using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity.Owin;
using ProjectManagement.Repositories;

namespace ProjectManagement.Web.Controllers
{
    public class LoginController: ApiController
    {
        private ApplicationSignInManager _signInManager;

        public LoginController()
        {
            //_signInManager = HttpContext.;
            _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
        }

        public class LoginDto
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login(LoginDto loginDto, string returnUrl = null)
        {
            var result = _signInManager.PasswordSignIn(loginDto.Username, loginDto.Password, true, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
                return Ok(new { Message = "Authenticated" });
            }
            else
            {
                return Unauthorized();
            }
            
        }
    }
}
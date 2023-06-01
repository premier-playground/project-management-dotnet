using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Repositories.Repositories;

namespace ProjectManagement.Domain.Services
{

    public class UserService
    {
        private IUserRepository _userRepository;


        public UserService(DbContext localDbContext)
        {
            _userRepository = new UserRepository(localDbContext);
        }


        public Student CreateStudent(StudentDTO studentDTO)
        {
            Student student = new Student(studentDTO.Name, studentDTO.Email, studentDTO.Role, studentDTO.Institution);

            var userManager = this.GetApplicationUserManager();

            IdentityResult result = userManager.Create(student, studentDTO.Password);

            if (!result.Succeeded) return null;

            bool setRoleSuccessed = this.SetUpUserRole(userManager, student, "STUDENT");

            return setRoleSuccessed ? student : null;
        }


        

        public Professor CreateProfessor(ProfessorDTO professorDTO)
        {
            Professor professor = new Professor(professorDTO.Name, professorDTO.Email,
                professorDTO.Role, professorDTO.Field, professorDTO.Degree);

            var userManager = this.GetApplicationUserManager();

            var result = userManager.Create(professor, professorDTO.Password);

            if (!result.Succeeded) return null;

            bool setRoleSuccessed = this.SetUpUserRole(userManager, professor, "PROFESSOR");

            return setRoleSuccessed ? professor : null;
        }

        private ApplicationUserManager GetApplicationUserManager()
        {
            ApplicationUserStore store = new ApplicationUserStore(new LocalDBContext());
            return new ApplicationUserManager(store);
        }


        private bool SetUpUserRole(ApplicationUserManager userManager, User user, String role)
        {
            User userToAddRole = userManager.FindByName(user.UserName);

            if (userToAddRole == null) return false;

            IdentityResult claimResult = userManager.AddClaim(user.Id, new Claim("role", role));

            if (!claimResult.Succeeded) return false;

            IdentityResult identityResult = userManager.AddToRole(userToAddRole.Id, role);

            return identityResult.Succeeded ? true : false;
        }
    }
}

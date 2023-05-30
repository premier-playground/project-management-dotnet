using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

            var store = new ApplicationUserStore(new LocalDBContext());
            var userManager = new ApplicationUserManager(store);
            var result = userManager.Create(student, studentDTO.Password);

            if (result.Succeeded)
            {
                return student;
            }

            return null;
        }

        public Professor CreateProfessor(ProfessorDTO professorDTO)
        {
            Professor professor = new Professor(professorDTO.Name, professorDTO.Email,
                professorDTO.Role, professorDTO.Field, professorDTO.Degree);

            var store = new ApplicationUserStore(new LocalDBContext());
            var userManager = new ApplicationUserManager(store);
            var result = userManager.Create(professor, professorDTO.Password);

            if (result.Succeeded)
            {
                return professor;
            }

            return null;
        }

    }
}

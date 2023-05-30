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
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Repositories.Manager;
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

            var userStore = new UserStore<User>();
            var manager = new AppUserManager(userStore);

            IdentityUser user = (IdentityUser)student;

            IdentityResult identityResult = manager.Create(user, studentDTO.Password);
            
            return _userRepository.InsertStudent(student);
        }

        public Professor CreateProfessor(ProfessorDTO professorDTO)
        {
            Professor professor = new Professor(professorDTO.Name, professorDTO.Email, professorDTO.Password,
                professorDTO.Role, professorDTO.Field, professorDTO.Degree);

            return _userRepository.InsertProfessor(professor);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
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
            Student student = new Student(studentDTO.Name, studentDTO.Email, studentDTO.Password, studentDTO.Role, studentDTO.Institution);
            
            return _userRepository.InsertStudent(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return this._userRepository.GetAllStudents();
        }

    public Professor CreateProfessor(ProfessorDTO professorDTO)
        {
            Professor professor = new Professor(professorDTO.Name, professorDTO.Email, professorDTO.Password,
                professorDTO.Role, professorDTO.Field, professorDTO.Degree);

            return _userRepository.InsertProfessor(professor);
        }

        public IEnumerable<Professor> GetAllProfessors() {
            return this._userRepository.GetAllProfessors();
        }

    }
}

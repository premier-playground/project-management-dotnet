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
using ProjectManagement.Domain.Mappers;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Repositories.Repositories;

namespace ProjectManagement.Domain.Services
{

    public class UserService: IUserService
    {
        private IUserRepository _userRepository;
        private CustomMapper _mapper;
        public UserService(DbContext localDbContext)
        {
            _userRepository = new UserRepository(localDbContext);
            _mapper = new CustomMapper();
        }

        public ReturnStudentDTO CreateStudent(StudentDTO studentDTO)
        {
            Student student = new Student(studentDTO.UserName, studentDTO.Email, studentDTO.Institution);

            var userManager = this.GetApplicationUserManager();

            IdentityResult result = userManager.Create(student, studentDTO.Password);

            if (!result.Succeeded) return null;

            bool setRoleSuccessed = this.SetUpUserRole(userManager, student, "STUDENT");

            return setRoleSuccessed ? this._mapper.Map<Student, ReturnStudentDTO>(student) : null;
        }

        public StudentGetDTO GetStudentById(string id)
        {
            var p = _userRepository.GetStudentById(id);
            if (p == null) return null;
            return new StudentGetDTO(p.Id, p.UserName, p.Email, p.Institution);
        }

        public List<StudentGetDTO> GetStudents()
        {
            return _userRepository.GetAllStudents()
                        .Select(p => new StudentGetDTO(p.Id, p.UserName, p.Email,  p.Institution))
                        .ToList();
        }

        public void UpdateStudent(StudentDTO studentDTO, string studentId)
        {
            Student student = this._userRepository.GetStudentById(studentId);
            student.Email = studentDTO.Email;
            student.Institution = studentDTO.Institution;

            this._userRepository.UpdateStudent(student);
        }

        public void DeleteStudent(string id)
        {
            Student student = this._userRepository.GetStudentById(id);
            this._userRepository.DeleteStudent(student);
        }

        public ReturnProfessorDTO CreateProfessor(ProfessorDTO professorDTO)
        {
            Professor professor = new Professor(professorDTO.UserName, professorDTO.Email, professorDTO.Field, professorDTO.Degree);

            var userManager = this.GetApplicationUserManager();

            var result = userManager.Create(professor, professorDTO.Password);

            if (!result.Succeeded) return null;

            bool setRoleSuccessed = this.SetUpUserRole(userManager, professor, "PROFESSOR");

            return setRoleSuccessed ? this._mapper.Map<Professor, ReturnProfessorDTO>(professor) : null;
        }

        public ProfessorGetDTO GetProfessorById(string id)
        {
            var p = _userRepository.GetProfessorById(id);
            if (p == null) return null;
            return new ProfessorGetDTO(p.Id, p.UserName, p.Email,p.Field, p.Degree);
        }

        public List<ProfessorGetDTO> GetProfessors()
        {
            return _userRepository.GetAllProfessors()
                        .Select(p => new ProfessorGetDTO(p.Id, p.UserName, p.Email, p.Field, p.Degree))
                        .ToList();
        }


        public void UpdateProfessor(ProfessorDTO professorDto, string professorId)
        {
            Professor professor = this._userRepository.GetProfessorById(professorId);
            professor.Email = professorDto.Email;
            professor.Degree = professorDto.Degree;
            professor.Field = professorDto.Field;

            this._userRepository.UpdateProfessor(professor);
        }

        public void DeleteProfessor(string id)
        {
            Professor professor = this._userRepository.GetProfessorById(id);
            this._userRepository.DeleteProfessor(professor);
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

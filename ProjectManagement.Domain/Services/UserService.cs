﻿using System;
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

            var store = new ApplicationUserStore(new LocalDBContext());
            var userManager = new ApplicationUserManager(store);
            var result = userManager.Create(student, studentDTO.Password);

            if (!result.Succeeded) return null;

            var userToAddRole = userManager.FindByName(student.UserName);
            if (userToAddRole == null) return null;

            var claimResult = userManager.AddClaim(student.Id, new Claim("role", "STUDENT"));
            if (!claimResult.Succeeded) return null;

            var identityResult = userManager.AddToRole(userToAddRole.Id, "STUDENT");
            return identityResult.Succeeded ? student : null;
        }

        public StudentGetDTO GetStudentById(string id)
        {
            var p = _userRepository.GetStudentById(id);
            return new StudentGetDTO(p.Id, p.UserName, p.Email, p.Role, p.Institution);
        }

        public List<StudentGetDTO> GetStudents()
        {
            return _userRepository.GetAllStudents()
                        .Select(p => new StudentGetDTO(p.Id, p.UserName, p.Email, p.Role, p.Institution))
                        .ToList();
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            Student student = this._userRepository.GetStudentByName(studentDTO.Name);
            student.Email = studentDTO.Email;
            student.Role = studentDTO.Role;
            student.Institution = studentDTO.Institution;

            this._userRepository.UpdateStudent(student);
        }

        public void DeleteStudent(string id)
        {
            Student student = this._userRepository.GetStudentById(id);

            this._userRepository.DeleteStudent(student);
        }

        public Professor CreateProfessor(ProfessorDTO professorDTO)
        {
            Professor professor = new Professor(professorDTO.Name, professorDTO.Email,
                professorDTO.Role, professorDTO.Field, professorDTO.Degree);

            var store = new ApplicationUserStore(new LocalDBContext());
            var userManager = new ApplicationUserManager(store);
            var result = userManager.Create(professor, professorDTO.Password);

            if (!result.Succeeded) return null;

            var userToAddRole = userManager.FindByName(professor.UserName);
            if (userToAddRole == null) return null;

            var claimResult = userManager.AddClaim(professor.Id, new Claim("role", "PROFESSOR"));
            if (!claimResult.Succeeded) return null;

            var identityResult = userManager.AddToRole(userToAddRole.Id, "PROFESSOR");
            return identityResult.Succeeded ? professor : null;
        }

        public List<ProfessorGetDTO> GetProfessors()
        {
            return _userRepository.GetAllProfessors()
                        .Select(p => new ProfessorGetDTO(p.Id, p.UserName, p.Email, p.Role, p.Field, p.Degree))
                        .ToList();
        }

       
    }
}

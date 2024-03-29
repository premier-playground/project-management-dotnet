﻿using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Repositories.Contexts;
using System.Data.Entity.Migrations;

namespace ProjectManagement.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            this._context = context;
        }

        public void DeleteStudent(Student student)
        {
            using (var localDbContext = new LocalDBContext())
            {
                localDbContext.Students.Remove(student);
                localDbContext.SaveChanges();

            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students = null;
            using (var localDbContext = new LocalDBContext())
            {
                students = localDbContext.Students.ToList();
            }
            return students;
        }

        public Student GetStudentById(string id)
        {
            Student student;

            using (var localDbContext = new LocalDBContext())
            {
                student = localDbContext.Students.FirstOrDefault(p => p.Id == id);
            }

            return student;
        }

        public Student GetStudentByName(string name)
        {
            Student student;

            using (var localDbContext = new LocalDBContext())
            {
                student = localDbContext.Students.FirstOrDefault(p => p.UserName == name);
            }

            return student;
        }

        public Student InsertStudent(Student student)
        {
            Student newStudent = null;

            using (var localDbContext = new LocalDBContext())
            {
                newStudent = localDbContext.Students.Add(student);
                localDbContext.SaveChanges();
            }

            return newStudent;
        }

        public void UpdateStudent(Student student)
        {
            
            using (var localDbContext = new LocalDBContext())
            {
                localDbContext.Students.AddOrUpdate(student);
                localDbContext.SaveChanges();
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Professor InsertProfessor(Professor professor)
        {
            Professor newProfessor = null;

            using (var localDbContext = new LocalDBContext())
            {
                newProfessor = localDbContext.Professors.Add(professor);
                localDbContext.SaveChanges();
            }

            return newProfessor;
        }

        public void UpdateProfessor(Professor professor)
        {
            throw new NotImplementedException();
        }

        public void DeleteProfessor(Professor professor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Professor> GetAllProfessors()
        {
            List<Professor> professors = null;
            using (var localDbContext = new LocalDBContext())
            {
                professors = localDbContext.Professors.ToList();
            }
            return professors;
        }

        public Professor GetProfessorById(string id)
        {
            Professor professor;

            using (var localDbContext = new LocalDBContext())
            {
                professor = localDbContext.Professors.FirstOrDefault(p => p.Id == id);
            }

            return professor;
        }
    }
}
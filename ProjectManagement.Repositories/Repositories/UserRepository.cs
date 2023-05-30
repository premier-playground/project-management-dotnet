using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Repositories.Contexts;

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
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {


            using (var localDbContext = new LocalDBContext())
            {
                return localDbContext.Students.ToList<Student>();

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
            

            using (var localDbContext = new LocalDBContext())
            {
                return localDbContext.Professors.ToList<Professor>();
                
            }

        }

        public Professor GetProfessorById(int id)
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
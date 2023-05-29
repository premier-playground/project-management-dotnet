using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Student> GetAllStudents()
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

            using (var localDbContext = (LocalDBContext) _context)
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
    }
}
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Repositories.Repositories
{
    public interface IUserRepository: IDisposable
    {
        Student InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
    }
}

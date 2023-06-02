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
        Student GetStudentById(string id);

        Student GetStudentByName(string name);

        Professor InsertProfessor(Professor professor);
        void UpdateProfessor(Professor professor);
        void DeleteProfessor(Professor professor);
        IEnumerable<Professor> GetAllProfessors();
        Professor GetProfessorById(string id);
    }
}

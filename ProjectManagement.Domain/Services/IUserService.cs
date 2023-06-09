using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Services
{
    public interface IUserService
    {
        ReturnStudentDTO CreateStudent(StudentDTO studentDTO);
        StudentGetDTO GetStudentById(string id);
        List<StudentGetDTO> GetStudents();
        void UpdateStudent(StudentDTO studentDTO, string studentId);
        void DeleteStudent(string id);
        ReturnProfessorDTO CreateProfessor(ProfessorDTO professorDTO);
        ProfessorGetDTO GetProfessorById(string id);
        List<ProfessorGetDTO> GetProfessors();
        void UpdateProfessor(ProfessorDTO professorDto, string professorId);
        void DeleteProfessor(string id);
    }
}

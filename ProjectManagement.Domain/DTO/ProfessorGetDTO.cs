using ProjectManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.DTO
{
    public class ProfessorGetDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Field { get; set; }
        public string Degree { get; set; }

        public ProfessorGetDTO(string id, string name, string email, Role role, string field, string degree)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            Field = field;
            Degree = degree;
        }
    }
}

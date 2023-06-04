using ProjectManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Domain.DTO
{
    public class StudentGetDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Institution { get; set; }

        public StudentGetDTO(string id, string name, string email, Role role, string institution)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            Institution = institution;
        }
    }
}
using ProjectManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Domain.DTO
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Institution { get; set; }
        public StudentDTO() { }
    }
}
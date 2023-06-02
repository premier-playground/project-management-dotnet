using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Entities.Models
{
    public class Student: User
    {
        public string Institution { get; set; }

        public Student(string name, string email, string institution) : base(name, email)
        {
            Institution = institution;
        }

        public Student(): base() {}
    }
}
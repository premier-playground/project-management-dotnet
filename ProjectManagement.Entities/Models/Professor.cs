using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Entities.Models
{
    public class Professor: User
    {
        public string Field { get; set; }
        public string Degree { get; set; }

        public Professor(int id, string name, string email, string password, Role role, string field, string degree) : base(id, name, email, password, role)
        {
            Field = field;
            Degree = degree;
        }

        public Professor(string name, string email, string password, Role role, string field, string degree) : base(
            name, email, password, role)
        {
            Field = field;
            Degree = degree;
        }

        public Professor(): base() { }
    }
}

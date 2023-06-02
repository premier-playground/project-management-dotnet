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

        public Professor(string name, string email, string field, string degree) : base(
            name, email)
        {
            Field = field;
            Degree = degree;
        }

        public Professor(): base() { }
    }
}

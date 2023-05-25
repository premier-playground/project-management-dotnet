using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entities.Models
{
    public class Professor: User
    {
        public string Field { get; set; }
        public string Degree { get; set; }
    }
}

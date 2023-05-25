using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Entities.Models
{
    public class StudentProjectAssociation
    {
        public string Id { get; set; }
        public Student Student { get; set; }
        public Level Level { get; set; }
        public DateTime AddedAt { get; set; }
    }
}

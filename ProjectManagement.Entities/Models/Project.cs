using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entities.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public Professor Coordinator { get; set; }
        public List<StudentProjectAssociation> StudentProjectAssociations { get; set; } = new List<StudentProjectAssociation>();
    }
}

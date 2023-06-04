using ProjectManagement.Entities.Enums;
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.DTO
{
    public class ProjectGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoordinatorId { get; set; }

        public ProjectGetDTO(int id, string name, string description, string coordinatorId)
        {
            Id = id;
            Name = name;
            Description = description;
            CoordinatorId = coordinatorId;
        }
    }

    
}

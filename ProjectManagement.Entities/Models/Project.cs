using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entities.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }


        [ForeignKey("Professor")]
        public int CoordinatorId { get; set; }
        public Professor Coordinator { get; set; }
        public virtual ICollection<StudentProjectAssociation> StudentProjectAssociations { get; set; }


        public Project(string name, string description, Professor coordinator)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
            CoordinatorId = coordinator.Id;
            Coordinator = coordinator;
        }

    }
    
}

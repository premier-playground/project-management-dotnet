using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Entities.Models
{
    public class StudentProjectAssociation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Level Level { get; set; }
        public DateTime AddedAt { get; set; }


        public StudentProjectAssociation(Level level)
        {
            this.Level = level;
            this.AddedAt = DateTime.Now;
            this.Student = null;
        }

        public StudentProjectAssociation() { }
    }
}

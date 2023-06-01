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
        //public virtual Project Project { get; set; }
        public virtual Student Student { get; set; }
        public Level Level { get; set; }
        public DateTime AddedAt { get; set; }


        //public StudentProjectAssociation(Student student, Level level, DateTime AddedAt)
        public StudentProjectAssociation(Level level)
        {
            this.Level = level;
            //this.AddedAt = AddedAt;
            this.AddedAt = DateTime.Now;
            //this.Project = null;
            this.Student = null;
        }

        public StudentProjectAssociation() { }
    }
}

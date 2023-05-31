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
        public string Id { get; set; }
        public Student Student { get; set; }
        public Level Level { get; set; }
        public DateTime AddedAt { get; set; }


        public StudentProjectAssociation(Student student, Level level, DateTime AddedAt)
        {
            this.Student = student;
            this.Level = level;
            this.AddedAt = AddedAt;
        }
    }
}

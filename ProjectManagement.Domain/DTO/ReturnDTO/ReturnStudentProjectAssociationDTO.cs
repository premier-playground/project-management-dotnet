using ProjectManagement.Entities.Enums;
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.DTO
{
    public class ReturnStudentProjectAssociationDTO
    {
        public int Id { get; set; }
        public ReturnStudentDTO Student { get; set; }
        public Level Level { get; set; }
        public DateTime AddedAt { get; set; }

    }
}

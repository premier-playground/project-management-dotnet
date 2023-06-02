using ProjectManagement.Entities.Enums;
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.DTO
{
    public class StudentProjectAssociationDTO
    {
        public string StudentId { get; set; }
        public Level Level { get; set; }

    }
}

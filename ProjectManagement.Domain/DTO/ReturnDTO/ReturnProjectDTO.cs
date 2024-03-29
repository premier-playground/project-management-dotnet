﻿using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.DTO
{
    public class ReturnProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ReturnProfessorDTO Coordinator { get; set; }
        public ICollection<ReturnStudentProjectAssociationDTO> StudentProjectAssociations { get; set; }
    }
}

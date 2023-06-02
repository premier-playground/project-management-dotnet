using ProjectManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Domain.DTO
{
    public class ReturnStudentDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Institution { get; set; }
    }
}
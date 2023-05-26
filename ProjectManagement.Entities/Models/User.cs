using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Entities.Models
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        protected User(int id, string name, string email, string password, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        protected User()
        {
        }
    }
}

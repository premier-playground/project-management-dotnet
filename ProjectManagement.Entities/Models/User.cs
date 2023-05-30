using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Entities.Models
{
    public abstract class User: IdentityUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public Role Role { get; set; }

        protected User(string name, string email, string password, Role role)
        {
            //Name = name;
            //Email = email;
            //Password = password;
            Role = role;
        }

        protected User(string name, string email, Role role)
        {
            UserName = name;
            Email = email;
            Role = role;
        }

        protected User()
        {
        }
    }
}

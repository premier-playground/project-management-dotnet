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

        protected User(string name, string email)
        {
            UserName = name;
            Email = email;
        }

        protected User() { }
    }
}

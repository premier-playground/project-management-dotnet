using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;

namespace ProjectManagement.Repositories
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }
    }

    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(LocalDBContext context) : base(context)
        {
        }
    }
}
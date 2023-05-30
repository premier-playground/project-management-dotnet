using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repositories.Manager
{
    public class AppUserManager: UserManager<User>
    {
        public AppUserManager(IUserStore<User> store) : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var appContext = new OwinContext().Get<IdentityDbContext>();

            var userManager = new AppUserManager(new UserStore<User>(appContext));

            return userManager;
        }
    }
}

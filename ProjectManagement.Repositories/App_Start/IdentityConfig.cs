using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;

namespace ProjectManagement.Repositories
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var store = new UserStore<User>(context.Get<LocalDBContext>());
            var manager = new ApplicationUserManager(store);
            return manager;
        }
    }

    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(LocalDBContext context) : base(context)
        {
        }
    }

    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
    public class UserSecurityTokenAuthentication
    {
        private ApplicationUserManager ApplicationUserManager { get; set; }

        public UserSecurityTokenAuthentication(ApplicationUserManager applicationUserManager)
        {
            ApplicationUserManager = applicationUserManager;
        }

        private bool VerifyPassword(string hashedPassword, string password)
        {
            var result = ApplicationUserManager.PasswordHasher.VerifyHashedPassword(hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }

        public bool Login(string userName, string password)
        {
            using (LocalDBContext context = new LocalDBContext())
            {
                var result = false;
                var user = context.Users.FirstOrDefault(u => u.UserName.Equals(userName));
                if (user != null)
                {
                    if (VerifyPassword(user.PasswordHash, password))
                    {
                        result = true;
                    }
                }

                return result;
            }
        }
    }
}
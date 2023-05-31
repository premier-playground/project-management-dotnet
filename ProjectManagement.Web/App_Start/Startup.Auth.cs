using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProjectManagement.Repositories;
using ProjectManagement.Repositories.Contexts;
using ProjectManagement.Web;

namespace ProjectManagement.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new LocalDBContext());
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/login"),
            //    Provider = new AccessProviderToken()
            //});
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                    Provider = new AccessProviderToken(new ApplicationUserManager(new ApplicationUserStore(new LocalDBContext())))
                }
            );
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public class AccessProviderToken: OAuthAuthorizationServerProvider
        {
            private ApplicationUserManager ApplicationUserManager { get; set; }

            public AccessProviderToken(ApplicationUserManager applicationUserManager)
            {
                ApplicationUserManager = applicationUserManager;
            }
            public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
                return Task.CompletedTask;
            }
            public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                //var result = _signInManager.PasswordSignIn(context.UserName, context.Password, true, shouldLockout: false);
                var result = new UserSecurityTokenAuthentication(ApplicationUserManager).Login(context.UserName, context.Password);
                if (result)
                {
                    using (var localDbContext = new LocalDBContext())
                    {
                        var user = localDbContext.Users.FirstOrDefault(u => u.UserName == context.UserName);
                        if (user != null)
                        {
                            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                            identity.AddClaim(new Claim("sub", context.UserName));
                            var roleId = user.Roles.ElementAt(0).RoleId;
                            var role = localDbContext.Roles.FirstOrDefault(r => r.Id == roleId);
                            if (role != null)
                            {
                                identity.AddClaim(new Claim("role", role.Name));
                            }
                            context.Validated(identity);

                        } else
                        {
                            context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
                        }
                        
                    }
                }
                else
                {
                    context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
                    return Task.CompletedTask;
                }

                return Task.CompletedTask;
            }
        }
    }
}
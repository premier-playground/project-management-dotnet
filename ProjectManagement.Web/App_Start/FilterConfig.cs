using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ProjectManagement.Web
{
    public class FilterConfig
    {
        public class ProfessorClaimsAuthorizeAttribute : AuthorizeAttribute
        {

            public override void OnAuthorization(HttpActionContext actionContext)
            {
                var user = HttpContext.Current.User as ClaimsPrincipal;
                var authorized = user?.Claims.FirstOrDefault(c => c.Type.Equals("role") && c.Value.Equals("PROFESSOR"));
                if (authorized != null)
                {
                    if (authorized.Value.Equals("PROFESSOR"))
                    {
                        base.OnAuthorization(actionContext);
                    }
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }

        public class GeneralUserClaimsAuthorizeAttribute : AuthorizeAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                var user = HttpContext.Current.User as ClaimsPrincipal;
                var authorized = user?.Claims.FirstOrDefault(c => c.Type.Equals("role"));
                if (authorized != null)
                {
                    if (authorized.Value.Equals("PROFESSOR") || authorized.Value.Equals("STUDENT"))
                    {
                        base.OnAuthorization(actionContext);
                    }
                }
                else
                {
                    this.HandleUnauthorizedRequest(actionContext);
                }
            }
        }
    }
}
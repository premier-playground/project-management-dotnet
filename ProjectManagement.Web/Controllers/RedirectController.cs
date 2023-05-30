using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace ProjectManagement.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RedirectController: ApiController
    {
        [Route("")]
        [AcceptVerbs("GET")]
        public RedirectResult Index()
        {
            return Redirect(Url.Content("~/swagger/ui/index"));
        }
    }
}
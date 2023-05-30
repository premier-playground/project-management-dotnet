using System.Web.Http;
using System.Web.Mvc;
using ProjectManagement.Web.Controllers;
using Swashbuckle.Application;
using ServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;

namespace ProjectManagement.Web
{
    public static class WebApiConfig
    {

        public static ServiceCollection Services { get; private set; }
        // public static ServiceProvider ServiceProvider { get; protected set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

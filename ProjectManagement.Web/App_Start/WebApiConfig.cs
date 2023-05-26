using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal;
using ProjectManagement.Repositories.Contexts;
using System.Web.Services.Description;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
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

﻿
using System.Web.Http;
using System.Web.Http.Cors;

namespace Aplicacao
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }

        public static void Register(HttpConfiguration config)
        {
            //config.EnableCors();
            var enableCorsAttribute = new EnableCorsAttribute("*",
                                               "Origin, Content-Type, Accept",
                                               "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(enableCorsAttribute);


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GeneralService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SetJsonSettings(config);
        }

        private static void SetJsonSettings(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

        }
    }
}

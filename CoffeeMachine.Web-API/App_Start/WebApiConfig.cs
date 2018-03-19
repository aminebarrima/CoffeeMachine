﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoffeeMachine.Web_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable cross-origin request
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            // config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RouteSpecifique",
                routeTemplate: "appii/{Controller}/{id}",
                defaults: new {Controller="Boissons",id=RouteParameter.Optional}
                );

            //Media-Type Formatters
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //Configure JSON Serialization:
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Banking_API
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
            /*
            config.Routes.MapHttpRoute(
                name: "transactions",
                routeTemplate: "api/{controller}/{origin}/{recipient}",
                defaults: new { origin = RouteParameter.Optional, recipient = RouteParameter.Optional, amount = RouteParameter.Optional }
            );
            */
        }
    }
}

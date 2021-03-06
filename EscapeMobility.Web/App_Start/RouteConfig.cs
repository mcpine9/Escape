﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EscapeMobility.Web.App_Start.LegacyRouteHandler;

namespace EscapeMobility
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AllProductsDefault",
                url: "AllProducts/Safety/{category}",
                defaults: new { controller = "AllProducts", action = "Safety", category = UrlParameter.Optional }
            );

            routes.MapRoute("Login", "site/login", new
            {
                controller = "Users",
                action = "DisplayLogin"
            });

            routes.MapRoute(
                    name: "APEscapeChair",
                    url: "products/all-products/evacuation/escape-chair.aspx",
                    defaults: new { controller = "AllProducts", action = "EscapeChair"}
                );

            routes.MapRoute(
                    name: "OBEscapeChair",
                    url: "products/office-buildings/evacuation/escape-chair.aspx",
                    defaults: new { controller = "OfficeBuildings", action = "EscapeChair"}
                );

            

            //routes.Add("", new LegacyRoute(
            //    "Users/Login.aspx",
            //    "Login",
            //    new LegacyRouteHandler()));
        }
    }
}

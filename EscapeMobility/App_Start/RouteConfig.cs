using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
                url: "AllProducts/{action}/{id}",
                defaults: new { controller = "AllProducts", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AllProductsSafetyDefault",
                url: "AllProducts/Safety/{action}/{id}",
                defaults: new { controller = "AllProductsSafety", action = "EmergencyAid", id = UrlParameter.Optional }
            );
        }
    }
}

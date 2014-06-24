using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EscapeMobility.Domain;
using EscapeMobility.Infrastructure;
using Ninject;
using Ninject.Web.Common;
using Tweetinvi;

namespace EscapeMobility
{
    public class MvcApplication : HttpApplication
    {
        protected new void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var myAppSettings = ConfigurationManager.AppSettings;
            TwitterCredentials.SetCredentials(
                myAppSettings["token_AccessToken"],
                myAppSettings["token_AccessTokenSecret"],
                myAppSettings["token_ConsumerKey"],
                myAppSettings["token_ConsumerSecret"]);
        }

    }
}

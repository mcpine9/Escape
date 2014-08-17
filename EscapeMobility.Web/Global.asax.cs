using System.Configuration;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Escape.Data;
using Tweetinvi;

namespace EscapeMobility.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new EscapeDataInitializer());
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

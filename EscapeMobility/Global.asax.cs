using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Escape.Data;
using Tweetinvi;

namespace EscapeMobility
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //System.Data.Entity.Database.SetInitializer(new EscapeDataInitializer());
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

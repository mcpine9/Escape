using System.Web;
using System.Web.Optimization;

namespace EscapeMobility
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/app/jquery-1.8.0.min.0219160602.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/lib/bootstrap/bootstrap.js",
                      "~/Scripts/lib/respond/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                    "~/Scripts/app/Main.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/styles/lib/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                    "~/Content/styles/lib/bootstrap.css",
                    "~/Content/styles/lib/font-awesome/font-awesome.css",
                    "~/Content/styles/app/adminlayout.css"));
        }
    }
}

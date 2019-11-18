using System.Web;
using System.Web.Optimization;

namespace DivingTracker.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new LessBundle("~/Content/less")
                .Include("~/Content/bootstrap-datetimepicker-build.less", 
                    "~/Content/colours.less",
                    "~/Content/site.less"));

            bundles.Add(new ScriptBundle("~/bundles/javascript")
                .Include(
                    "~/Scripts/moment-with-locales.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/bootstrap-datetimepicker.js",
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery-ui-{version}.js",
                    "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));
        }
    }
}

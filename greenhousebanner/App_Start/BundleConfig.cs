using System.Web;
using System.Web.Optimization;

namespace greenhousebanner
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Home/default").Include("~/Content/bootstrap.css",
                                                                          "~/Content/Home/shop-homepage.css"));


            bundles.Add(new StyleBundle("~/Content/Admin/default").Include("~/Content/Admin/default.css",
                                                                           "~/Content/Admin/color.css",
                                                                           "~/Content/Admin/iconFont.css",
                                                                           "~/Content/Admin/jquery-ui.css",
                                                                           "~/Content/Admin/main.css",
                                                                           "~/Content/Admin/media.css",
                                                                           "~/Content/Admin/pushy.css"));

            bundles.Add(new ScriptBundle("~/java/googleajaxjquery").Include("~/Scripts/java/googleajax-jquery-ui.min-1.8.2.js", "~/Scripts/java/pushy.min.js"));
        }
    }
}

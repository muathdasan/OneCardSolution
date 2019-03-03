using System.Web;
using System.Web.Optimization;

namespace OneCard.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-3.3.1.js",
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/DataTables/jquery.dataTables.js",
                         "~/Scripts/DataTables/dataTables.bootstrap.js",
                           "~/Scripts/jquery-ui-1.12.1.js",
                         //  "~/Scripts/Webcam/webcam.min.js",
                          "~/Scripts/script.js" ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/lib").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.css",
                       //  "~/Content/bootstrap-cosmo.css",
                       "~/Content/DataTables/dataTables.bootstrap.css",
                        "~/Content/themes/base/jquery-ui.css",
                          "~/Content/themes/base/datepicker.css",
                      "~/Content/site.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/InternalStylesAr").Include(
                      //"~/Content/bootstrap-rtl.min.css",
                      "~/Content/bootstrap-rtl.css",
                      //"~/Content/bootstrap-grid-rtl.min.css",
                      //"~/Content/bootstrap-grid-rtl.css",
                      "~/Content/style-rtl.css"));

            bundles.Add(new ScriptBundle("~/bundles/InternalScriptsAr").Include(
                     "~/Scripts/bootstrap-rtl.min.js",
                     "~/Scripts/bootstrap-rtl.js"));

        }
    }
}

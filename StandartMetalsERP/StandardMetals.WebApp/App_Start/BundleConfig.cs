using System.Web;
using System.Web.Optimization;

namespace StandardMetals.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {




            bundles.Add(new ScriptBundle("~/bower_componentsJS").Include(
                     "~/Scripts/jquery-3.3.1.js").Include(
                     "~/bower_components/bootstrap/dist/js/bootstrap.min.js").Include(
                     "~/bower_components/datatables.net/jquery.dataTables.min.js")
                     //.Include(
                     //"~/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js")
                     .Include(
                     "~/bower_components/select2/dist/js/select2.full.min.js").Include(
                     "~/dist/js/adminlte.min.js"));

            bundles.Add(new StyleBundle("~/bower_componentsDistCSS").Include(
                       "~/bower_components/bootstrap/dist/css/bootstrap.min.css").Include(
                       "~/bower_components/font-awesome/css/font-awesome.min.css").Include(
                       "~/bower_components/Ionicons/css/ionicons.min.css").Include(
                       "~/bower_components/select2/dist/css/select2.min.css").Include(
                       "~/dist/css/AdminLTE.min.css").Include(
                       "~/dist/css/skins/skin-blue.min.css").Include
                       ("~/bower_components/DataTable_Library/css/jquery.dataTables.css"));
              

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));


        }
    }
}

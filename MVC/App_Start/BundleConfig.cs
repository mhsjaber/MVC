using System.Web;
using System.Web.Optimization;

namespace MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/customjs").Include(
                      "~/CustomContent/plugins/sparkline/jquery.sparkline.min.js",
                      "~/CustomContent/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                      "~/CustomContent/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                      "~/CustomContent/plugins/knob/jquery.knob.js",
                      "~/CustomContent/plugins/daterangepicker/daterangepicker.js",
                      "~/CustomContent/plugins/datepicker/bootstrap-datepicker.js",
                      "~/CustomContent/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                      "~/CustomContent/plugins/slimScroll/jquery.slimscroll.min.js",
                      "~/CustomContent/plugins/fastclick/fastclick.js",
                      "~/CustomContent/dist/js/app.min.js",
                      "~/CustomContent/plugins/datatables/jquery.dataTables.js",
                      "~/CustomContent/plugins/datatables/dataTables.bootstrap.js",
                      "~/CustomContent/dist/js/demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/customcss").Include(
                      "~/CustomContent/dist/css/AdminLTE.min.css",
                      "~/CustomContent/dist/css/skins/_all-skins.min.css",
                      "~/CustomContent/plugins/iCheck/flat/blue.css",
                      "~/CustomContent/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                      "~/CustomContent/plugins/datepicker/datepicker3.css",
                      "~/CustomContent/plugins/daterangepicker/daterangepicker.css",
                      "~/CustomContent/plugins/datatables/dataTables.bootstrap.css",
                      "~/CustomContent/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"));
        }
    }
}

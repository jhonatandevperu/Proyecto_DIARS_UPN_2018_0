using System.Web;
using System.Web.Optimization;

namespace EscalaConstructoresSAC
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/js/lib/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/js/lib/jquery-validation/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/js/lib/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/js/lib/bootstrap/bootstrap.min.js",
            "~/js/lib/respond/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
            "~/js/lib/popper/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
            "~/js/plugins.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
            "~/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/tether").Include(
            "~/js/lib/tether/tether.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/js/lib/jqueryui/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/lobipanel").Include(
            "~/js/lib/lobipanel/lobipanel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/matchHeight").Include(
            "~/js/lib/match-height/jquery.matchHeight.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
            "~/js/lib/datatables-net/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/flatpickr").Include(
            "~/js/lib/flatpickr/flatpickr.min.js"));

            //Styles

            bundles.Add(new StyleBundle("~/maincss").Include(
            "~/css/lib/lobipanel/lobipanel.min.css",
            "~/css/separate/vendor/lobipanel.min.css",
            "~/css/lib/jqueryui/jquery-ui.min.css",
            "~/css/separate/pages/widgets.min.css",
            "~/css/lib/font-awesome/font-awesome.min.css",
            "~/css/lib/bootstrap/bootstrap.min.css",
            "~/css/main.css"));

            bundles.Add(new StyleBundle("~/datatables").Include(
            "~/css/lib/datatables-net/datatables.min.css",
            "~/css/separate/vendor/datatables-net.min.css"));

            bundles.Add(new StyleBundle("~/flatpickr").Include(
            "~/css/lib/flatpickr/flatpickr.min.css",
            "~/css/separate/vendor/flatpickr.min.css"));

            bundles.Add(new StyleBundle("~/login").Include(
            "~/css/separate/pages/login.min.css"));
        }
    }
}

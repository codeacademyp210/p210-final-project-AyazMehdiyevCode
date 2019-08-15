using System.Web;
using System.Web.Optimization;

namespace _56_Xeber
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Validation").Include(
                        "~/Public/js/jquery-3.3.1.min.js",
                        "~/Public/js/jquery.validate.min.js",
                        "~/Public/js/jquery.validate.unobtrusive.min.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/jquery&bootstrap").Include(
                        "~/Public/js/bootstrap.min.js",
                         "~/Public/js/jquery-3.4.1.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/header").Include(
                        "~/Public/js/currencies.js",
                         "~/Public/js/Weather.js",
                         "~/Public/js/navbar.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/header").Include(
                        "~/Public/js/currencies.js",
                        "~/Public/js/Weather.js",
                        "~/Public/js/navbar.js"
                        ));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Public/css/bootstrap.min.css",
                        "~/Public/css/style.css"));
        }
    }
}

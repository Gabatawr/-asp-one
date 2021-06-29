using System.Web;
using System.Web.Optimization;

namespace hw_1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/pe-icon.css",
                      "~/Content/grid.css",
                      "~/Content/magnific-popup.min.css",
                      "~/Content/swiper.css",
                      "~/Content/main.css"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/imagesloaded.pkgd.js",
                        "~/Scripts/isotope.pkgd.js",
                        "~/Scripts/jquery.nav.min.js",
                        "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/jquery.matchHeight.min.js",
                        "~/Scripts/jquery.magnific-popup.min.js",
                        "~/Scripts/masonry.pkgd.js",
                        "~/Scripts/jquery.waypoints.min.js",
                        "~/Scripts/swiper.jquery.js",
                        "~/Scripts/menu.js",
                        "~/Scripts/typed.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/main.js"));
        }
    }
}

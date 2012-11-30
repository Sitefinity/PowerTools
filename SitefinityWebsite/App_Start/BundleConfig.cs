using System;
using System.Linq;
using System.Web.Optimization;

namespace SitefinityWebApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Styles/Designer").Include(
                    "~/Styles/Bootstrap/css/bootstrap.min.css",
                    "~/Styles/Bootstrap/css/bootstrap-responsive.min.css",
                    "~/Styles/jQueryUI/jquery-ui-1.9.2.custom.min.css",
                    "~/Styles/designers.css"
                )
            );

            bundles.Add(new ScriptBundle("~/Scripts/Designer").Include(
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/underscore.min.js",
                    "~/Scripts/backbone.min.js",
                    "~/Scripts/jquery-ui-1.9.2.custom.min.js",
                    "~/Scripts/adhoc-list.designer.js"
               )
            );
        }
    }
}
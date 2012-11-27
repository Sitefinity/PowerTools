using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SitefinityWebApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/myscripts").Include(
                "~/Scripts/myscript1.js",
                "~/Scripts/myscript2.js")
            );

            bundles.Add(new StyleBundle("~/Styles/mystyles").Include(
                "~/Styles/mystyle1.css",
                "~/Styles/mystyle2.css")
            );

        }
    }
}
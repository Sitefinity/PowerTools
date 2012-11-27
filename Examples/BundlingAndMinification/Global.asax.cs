using System;
using System.Linq;
using System.Web.Optimization;
using Sitefinity.PowerTools;
using SitefinityWebApp.App_Start;
using SitefinityWebApp.RootTemplates;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            PowerTools.Instance
                      .RootTemplates
                      .RegisterMvcTemplateResolver<CustomMvcRootResolver>();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
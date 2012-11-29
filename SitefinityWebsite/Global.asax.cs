using System;
using System.Linq;
using System.Web.Optimization;
using Sitefinity.PowerTools;
using SitefinityWebApp.App_Start;
using SitefinityWebApp.Mvc.Controllers;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // register web forms resolver
            PowerTools.Instance
                      .RootTemplates
                      .RegisterWebFormsTemplateResolver<CustomWebFormsTemplateResolver>();

            // register mvc designers
            PowerTools.Instance
                      .Mvc
                      .RegisterDesigner<AdHocListController, AdHocListDesignerController>();

            // register bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
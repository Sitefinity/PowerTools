using System;
using System.Linq;
using Sitefinity.PowerTools;
using SitefinityWebApp.RootTemplates;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            PowerTools.Instance
                      .RootTemplates
                      .RegisterWebFormsTemplateResolver<CustomWebFormsResolver>();
        }
        
    }
}
using System;
using System.Linq;
using System.Web.Hosting;
using Sitefinity.PowerTools.RootTemplates;

namespace SitefinityWebApp.RootTemplates
{
    public class CustomMvcRootResolver : IRootTemplateResolver
    {
        public RootTemplate ResolveTemplate(RootTemplate rootTemplate, System.Web.Routing.RequestContext requestContext, string theme)
        {
            var filePath = HostingEnvironment.MapPath("~/RootTemplates/MvcFrontendTemplate.html");
            return rootTemplate.FromFile(filePath);
        }
    }
}
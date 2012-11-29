using System;
using System.Linq;
using System.Web.Hosting;
using System.Web.Routing;
using Sitefinity.PowerTools.RootTemplates;

namespace SitefinityWebApp
{
    public class CustomWebFormsTemplateResolver : IRootTemplateResolver
    {
        public RootTemplate ResolveTemplate(RootTemplate rootTemplate, RequestContext requestContext, string theme)
        {
            // Resolve only template for the front-end pages
            if (!rootTemplate.IsBackend)
            {
                var filePath = HostingEnvironment.MapPath("~/RootTemplates/FrontendRoot.Master");
                return rootTemplate.FromFile(filePath);
            }

            return rootTemplate;
        }
    }
}
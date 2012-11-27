using System;
using System.Linq;
using System.Web.Hosting;
using System.Web.Routing;
using Sitefinity.PowerTools.RootTemplates;

namespace SitefinityWebApp.RootTemplates
{
    public class CustomWebFormsResolver : IRootTemplateResolver
    {
        public RootTemplate ResolveTemplate(RootTemplate rootTemplate, RequestContext requestContext, string theme)
        {
            if (!rootTemplate.IsBackend)
            {
                var templatePath = HostingEnvironment.MapPath("~/RootTemplates/WebFormsHtml5.html");
                return rootTemplate.FromFile(templatePath);
            }

            return rootTemplate;
        }
    }
}
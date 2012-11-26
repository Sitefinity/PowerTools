using System;
using System.Linq;
using System.Web.Routing;
using Sitefinity.PowerTools.RootTemplates;

namespace Sitefinity.PowerTools.Test.RootTemplates.Wrappers
{
    public class TestRootTemplateResolver : IRootTemplateResolver
    {
        public RootTemplate ResolveTemplate(RootTemplate rootTemplate, RequestContext requestContext, string theme)
        {
            rootTemplate.FromString("This is test root template");
            return rootTemplate;
        }
    }
}

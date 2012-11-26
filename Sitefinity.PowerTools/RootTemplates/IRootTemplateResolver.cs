using System.Web.Routing;

namespace Sitefinity.PowerTools.RootTemplates
{
    public interface IRootTemplateResolver
    {
        RootTemplate ResolveTemplate(RootTemplate rootTemplate, RequestContext requestContext, string theme);
    }
}
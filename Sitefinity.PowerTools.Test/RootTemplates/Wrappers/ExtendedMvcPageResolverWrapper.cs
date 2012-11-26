using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Sitefinity.PowerTools.RootTemplates;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Pages.Model;

namespace Sitefinity.PowerTools.Test.RootTemplates.Wrappers
{
    public class ExtendedMvcPageResolverWrapper : ExtendedMvcPageResolver
    {
        public void InvokeBuildPageTemplateRecursive(IPageTemplate pageTemplate, string theme, RequestContext context, StringBuilder output, CursorCollection placeHolders, DirectiveCollection directives, List<IControlsContainer> controlConatiners)
        {
            this.BuildPageTemplateRecursive(pageTemplate, theme, context, output, placeHolders, directives, controlConatiners);
        }
    }
}

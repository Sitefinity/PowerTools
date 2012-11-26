using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Autofac;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Mvc.Rendering;
using Telerik.Sitefinity.Pages.Model;

namespace Sitefinity.PowerTools.RootTemplates
{
    public class ExtendedMvcPageResolver : PureMvcPageResolver
    {
        protected override void BuildPageTemplateRecursive(IPageTemplate pageTemplate, string theme, RequestContext context, StringBuilder output, CursorCollection placeHolders, DirectiveCollection directives, List<IControlsContainer> controlConatiners)
        {
            controlConatiners.Add(pageTemplate);

            if (!String.IsNullOrEmpty(pageTemplate.MasterPage))
            {
                this.BuildWithMasterPage(pageTemplate.MasterPage, context, output, placeHolders, directives);
                return;
            }

            if (!String.IsNullOrEmpty(pageTemplate.ExternalPage))
            {
                this.BuildWithExternalPage(pageTemplate.ExternalPage, context, output, placeHolders, directives);
                return;
            }

            if (this.BuildTemplateFromPresentationData(pageTemplate.Presentation, theme, output, placeHolders, directives, context))
                return;

            if (pageTemplate.ParentTemplate != null)
            {
                BuildPageTemplateRecursive(pageTemplate.ParentTemplate, theme, context, output, placeHolders, directives, controlConatiners);
                return;
            }

            RootTemplate result = this.GetRootTemplate(new RootTemplate(), context, theme);
            this.ProcessStringTemplate(result.Template, output, placeHolders, directives);
        }

        protected virtual void BuildPageTemplate(PageData pageData, string theme, RequestContext context,
            StringBuilder output, CursorCollection placeHolders,
            DirectiveCollection directives, List<IControlsContainer> controlConatiners)
        {
            controlConatiners.Add(pageData);

            if (!String.IsNullOrEmpty(pageData.MasterPage))
            {
                this.BuildWithMasterPage(pageData.MasterPage, context, output, placeHolders, directives);
                return;
            }

            if (!String.IsNullOrEmpty(pageData.ExternalPage))
            {
                this.BuildWithExternalPage(pageData.ExternalPage, context, output, placeHolders, directives);
                return;
            }

            if (this.BuildTemplateFromPresentationData(pageData.Presentation, theme, output, placeHolders, directives))
                return;

            if (pageData.Template != null)
            {
                BuildPageTemplateRecursive(pageData.Template, theme, context, output, placeHolders, directives, controlConatiners);
                return;
            }

            RootTemplate result = this.GetRootTemplate(new RootTemplate(), context, theme);
            this.ProcessStringTemplate(result.Template, output, placeHolders, directives);
        }

        protected bool BuildTemplateFromPresentationData(IEnumerable<PresentationData> presentation, string theme,
            StringBuilder output, CursorCollection placeHolders, DirectiveCollection directives, RequestContext context)
        {
            RootTemplate result = new RootTemplate();
            foreach (PresentationData item in presentation)
            {
                if (item.DataType == Presentation.HtmlDocument)
                {
                    var key = item.Theme ?? "Default";
                    if (key.Equals(theme, StringComparison.OrdinalIgnoreCase))
                    {
                        result = result.FromString(item.Data);
                        break;
                    }
                    if (result == null)
                        result = result.FromString(item.Data);
                }
            }

            result = this.GetRootTemplate(result, context, theme);

            if (!String.IsNullOrEmpty(result.Template))
            {
                this.ProcessStringTemplate(result.Template, output, placeHolders, directives);
                return true;
            }
            return false;
        }

        private RootTemplate GetRootTemplate(RootTemplate rootTemplate, RequestContext requestContext, string theme)
        {
            IRootTemplateResolver resolver = PowerTools.Instance
                                                       .Container
                                                       .ResolveNamed<IRootTemplateResolver>("Mvc");

            return resolver.ResolveTemplate(rootTemplate, requestContext, theme);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitefinity.PowerTools.Test.RootTemplates.Mocks;
using Sitefinity.PowerTools.Test.RootTemplates.Wrappers;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Pages.Model;

namespace Sitefinity.PowerTools.Test.RootTemplates
{
    [TestClass]
    public class PowerToolsRootTemplates_Should
    {
        [TestMethod]
        public void ObtainRootTemplateFromRegisteredMvcTemplateResolver_WhenBuildPageTemplateRecursiveMethodIsCalledForTheMvcPages()
        {
            PowerTools.Instance
                      .RootTemplates
                      .RegisterMvcTemplateResolver<TestRootTemplateResolver>();

            IPageTemplate pageTemplate = new PageTemplateMock();
            string theme = null;
            RequestContext context = new RequestContext();
            StringBuilder output = new StringBuilder();
            CursorCollection placeHolders = new CursorCollection();
            DirectiveCollection directives = new DirectiveCollection();
            List<IControlsContainer> controlContainers = new List<IControlsContainer>();

            var mvcPageResolver = new ExtendedMvcPageResolverWrapper();
            mvcPageResolver.InvokeBuildPageTemplateRecursive(pageTemplate, theme, context, output, placeHolders, directives, controlContainers);

            Assert.AreEqual("This is test root template", output.ToString());
        }

        [TestMethod]
        public void ObtainRootTemplateFromRegisteredWebFormsTemplateResolver_WhenBuildPageTemplateRecursiveMethodIsCalledForWebFormsPages()
        {
            PowerTools.Instance
                      .RootTemplates
                      .RegisterWebFormsTemplateResolver<TestRootTemplateResolver>();

            IPageTemplate pageTemplate = new PageTemplateMock();
            string theme = null;
            RequestContext context = new RequestContext();
            StringBuilder output = new StringBuilder();
            CursorCollection placeHolders = new CursorCollection();
            DirectiveCollection directives = new DirectiveCollection();
            List<IControlsContainer> controlContainers = new List<IControlsContainer>();

            var mvcPageResolver = new ExtendedWebFormsPageResolverWrapper();
            mvcPageResolver.InvokeBuildPageTemplateRecursive(pageTemplate, theme, context, output, placeHolders, directives, controlContainers);

            Assert.AreEqual("This is test root template", output.ToString());
        }

    }
}

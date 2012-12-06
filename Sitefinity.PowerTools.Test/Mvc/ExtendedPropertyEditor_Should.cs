using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.Sitefinity.Mvc.Proxy;
using Autofac;
using Sitefinity.PowerTools.Mvc;

namespace Sitefinity.PowerTools.Test.Mvc
{
    [TestClass]
    public class ExtendedPropertyEditor_Should
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            var store = PowerTools.Instance.Container.Resolve<IMvcDesignerStore>();
            store.MvcDesigners.Clear();
        }

        [TestMethod]
        public void ThrowAnException_WhenResolveMvcDesignerIsCalledWithWidgetTypeArgumentBeingNull()
        {
            try
            {
                var propEditor = new ExtendedPropertyEditorWrapper();
                propEditor.InvokeResolveMvcDesigner(null);
                Assert.Fail("ArgumentNullException was supposed to be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("widgetType", ex.ParamName);
            }
        }

        [TestMethod]
        public void ReturnNull_WhenResolveMvcDesignerIsCalledAndNoDesignerForPassedWidgetTypeIsPresentInTheMvcDesignerStore()
        {
            var propEditor = new ExtendedPropertyEditorWrapper();
            var designer = propEditor.InvokeResolveMvcDesigner(typeof(WidgetType));
            Assert.IsNull(designer);
        }

        [TestMethod]
        public void ReturnAnInstanceOfMvcControllerProxyWithControllerNameSet_WhenResolveMvcDesignerIsCalledWithWidgetTypeThatIsPresentInMvcDesignerStore()
        {
            PowerTools.Instance.Mvc.RegisterDesigner<WidgetType, WidgetDesigner>();

            var propEditor = new ExtendedPropertyEditorWrapper();
            var designer = propEditor.InvokeResolveMvcDesigner(typeof(WidgetType));

            Assert.IsNotNull(designer);
            Assert.IsInstanceOfType(designer, typeof(MvcControllerProxy));
            Assert.AreEqual(typeof(WidgetDesigner).FullName, designer.ControllerName);
        }

        private class WidgetType
        {
        }

        private class WidgetDesigner : Controller
        {
        }
    }
}

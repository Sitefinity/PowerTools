using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.Sitefinity.Mvc.Proxy;
using Autofac;
using Sitefinity.PowerTools.Mvc;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

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
            var designer = propEditor.InvokeResolveMvcDesigner(typeof(Widget));
            Assert.IsNull(designer);
        }

        [TestMethod]
        public void ReturnAnInstanceOfMvcControllerProxyWithControllerNameSet_WhenResolveMvcDesignerIsCalledWithWidgetTypeThatIsPresentInMvcDesignerStore()
        {
            PowerTools.Instance.Mvc.RegisterDesigner<Widget, WidgetDesigner>();

            var propEditor = new ExtendedPropertyEditorWrapper();
            var designer = propEditor.InvokeResolveMvcDesigner(typeof(Widget));

            Assert.IsNotNull(designer);
            Assert.IsInstanceOfType(designer, typeof(MvcControllerProxy));
            Assert.AreEqual(typeof(WidgetDesigner).FullName, designer.ControllerName);
        }

        [TestMethod]
        public void ThrowAnException_WhenResolveWidgetTypeIsCalledWithNullForControlDataArgument()
        {
            try
            {
                var propEditor = new ExtendedPropertyEditorWrapper();
                propEditor.InvokeResolveWidgetType(null);
                Assert.Fail("ArgumentNullException was supposed to be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("ctrlData", ex.ParamName);
            }
        }

        [TestMethod]
        public void ReturnTheActualTypeOfControlData_WhenResolveWidgetTypeIsCallWithATypeThatIsNotMvcControllerProxy()
        {
            var pageControl = new PageControl();
            pageControl.ObjectType = typeof(Widget).FullName;

            TypeResolutionService.RegisterType(typeof(Widget));

            var propEditor = new ExtendedPropertyEditorWrapper();
            var widgetType = propEditor.InvokeResolveWidgetType(pageControl);

            Assert.AreEqual(typeof(Widget), widgetType);
        }

        [TestMethod]
        public void ReturnTheTypeOfTheController_WhenResolveWidgetTypeIsCalledWithATypeThatIsMvcControllerProxy()
        {
            var pageControl = new PageControl();
            pageControl.ObjectType = typeof(MvcControllerProxy).FullName;
            pageControl.Properties.Add(new ControlProperty()
            {
                Name = "ControllerName",
                Value = typeof(WidgetDesigner).FullName
            });

            TypeResolutionService.RegisterType(typeof(WidgetDesigner));

            var propEditor = new ExtendedPropertyEditorWrapper();
            var widgetType = propEditor.InvokeResolveWidgetType(pageControl);

            Assert.AreEqual(typeof(WidgetDesigner), widgetType);
        }

        private class Widget
        {
        }

        private class WidgetDesigner : Controller
        {
        }
    }
}

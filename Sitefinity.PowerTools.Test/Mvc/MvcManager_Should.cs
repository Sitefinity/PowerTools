using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitefinity.PowerTools.Mvc;
using Autofac;

namespace Sitefinity.PowerTools.Test.Mvc
{
    [TestClass]
    public class MvcManager_Should
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            var mvcDesignerStore = PowerTools.Instance.Container.Resolve<IMvcDesignerStore>();
            mvcDesignerStore.MvcDesigners.Clear();
        }

        [TestMethod]
        public void AddADesignerForWidgetToMvcDesignerStore_WhenRegisterDesignerIsCalled()
        {
            var mvcManager = new MvcManager();
            mvcManager.RegisterDesigner<WidgetType, WidgetDesigner>();

            var mvcDesignerStore = PowerTools.Instance.Container.Resolve<IMvcDesignerStore>();
            Assert.AreEqual(1, mvcDesignerStore.MvcDesigners.Keys.Count);
            Assert.AreEqual(typeof(WidgetDesigner), mvcDesignerStore.MvcDesigners[typeof(WidgetType)]);
        }

        [TestMethod]
        public void ThrowAnException_WhenRegisterDesignerIsCalledForTheWidgetTypeThatAlreadyHasARegisteredWidget()
        {
            var mvcManager = new MvcManager();
            mvcManager.RegisterDesigner<WidgetType, WidgetDesigner>();

            try
            {
                mvcManager.RegisterDesigner<WidgetType, WidgetDesigner>();
                Assert.Fail("Exception was supposed to be thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(string.Format("A designer for widget of type '{0}' has already been registered.", typeof(WidgetType).FullName), ex.Message);
            }
        }

        private class WidgetType
        {
        }

        private class WidgetDesigner : Controller
        {
        }

    }
}

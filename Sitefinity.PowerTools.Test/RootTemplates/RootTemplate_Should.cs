using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitefinity.PowerTools.RootTemplates;
using System.IO;

namespace Sitefinity.PowerTools.Test.RootTemplates
{
    [TestClass]
    public class RootTemplate_Should
    {
        [TestMethod]
        public void ReturnNull_WhenClassHasBeenCreatedWithADefaultConstructor()
        {
            var rootTemplate = new RootTemplate();
            Assert.IsNull(rootTemplate.Template);
        }

        [TestMethod]
        public void ThrowAnException_WhenATemplateConstructorIsUsedAndArgumentIsNull()
        {
            try
            {
                var rootTemplate = new RootTemplate(null);
                Assert.Fail("ArgumentNullException should be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("template", ex.ParamName);
            }
        }

        [TestMethod]
        public void SetTemplate_WhenATemplateConstructorIsUsedAnTemplateStringIsPassed()
        {
            var rootTemplate = new RootTemplate("abc");
            Assert.AreEqual("abc", rootTemplate.Template);
        }

        [TestMethod]
        public void ThrowAnException_WhenFromStringMethodIsCalledAnNullIsPassed()
        {
            var rootTemplate = new RootTemplate();
            try
            {
                rootTemplate.FromString(null);
                Assert.Fail("ArgumentNullException should be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("template", ex.ParamName);
            }
        }

        [TestMethod]
        public void SetTemplate_WhenFromStringMethodIsCalled()
        {
            var rootTemplate = new RootTemplate();
            rootTemplate.FromString("abc");
            Assert.AreEqual("abc", rootTemplate.Template);
        }

        [TestMethod]
        public void ThrowAnException_WhenFromFileIsCalledAndNullIsPassedForFilePath()
        {
            var rootTemplate = new RootTemplate();
            try
            {
                rootTemplate.FromFile(null);
                Assert.Fail("ArgumentNullException should be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("filePath", ex.ParamName);
            }
        }

        [TestMethod]
        public void SetTemplateFromFile_WhenFromFileHasBeenCalledWithProperFilePath()
        {
            var fileName = "roottemplate.txt";
            var fileContent = "Root template 1";

            try
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.Write(fileContent);
                }
                
                var rootTemplate = new RootTemplate();
                rootTemplate = rootTemplate.FromFile(fileName);
                Assert.AreEqual(fileContent, rootTemplate.Template);
            }
            finally
            {
                File.Delete(fileName);
            }

        }

        [TestMethod]
        public void ThrowAnException_WhenFromEmbeddedFileIsCalledAndNullIsPassedForResourceNameArgument()
        {
            var rootTemplate = new RootTemplate();
            try
            {
                rootTemplate.FromEmbeddedFile(null, typeof(RootTemplate));
                Assert.Fail("ArgumentNullException should be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("resourceName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ThrowAnException_WhenFromEmbeddedFileIsCalledAndNullIsPassedForAssemblyInfoArgument()
        {
            var rootTemplate = new RootTemplate();
            try
            {
                rootTemplate.FromEmbeddedFile("file", null);
                Assert.Fail("ArgumentNullException should be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("assemblyInfo", ex.ParamName);
            }
        }

        [TestMethod]
        public void SetTemplateFromEmbeddedFile_WhenFromEmbeddedFileHasBeenCalledWithProperResourceNameAndAssemblyInfo()
        {
            var rootTemplate = new RootTemplate();
            rootTemplate = rootTemplate.FromEmbeddedFile("Sitefinity.PowerTools.Test.RootTemplates.roottemplate.txt", this.GetType());
            Assert.AreEqual("Root template 1", rootTemplate.Template);
        }

    }
}

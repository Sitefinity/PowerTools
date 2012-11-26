using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Sitefinity.PowerTools.RootTemplates
{
    public class RootTemplate
    {
        public RootTemplate() { }

        public RootTemplate(string template)
        {
            if (string.IsNullOrEmpty(template))
                throw new ArgumentNullException("template");

            this.template = template;
        }

        public string Template
        {
            get
            {
                return this.template;
            }
        }

        public RootTemplate FromString(string template)
        {
            if (string.IsNullOrEmpty(template))
                throw new ArgumentNullException("template");

            this.template = template;
            return this;
        }

        public RootTemplate FromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            this.template = File.ReadAllText(filePath);
            return this;
        }

        public RootTemplate FromEmbeddedFile(string resourceName, Type assemblyInfo)
        {
            if (string.IsNullOrEmpty(resourceName))
                throw new ArgumentNullException("resourceName");

            if (assemblyInfo == null)
                throw new ArgumentNullException("assemblyInfo");

            using (Stream stream = assemblyInfo.Assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    this.template = reader.ReadToEnd();
                }
            }

            return this;
        }

        private string template;
    }
}

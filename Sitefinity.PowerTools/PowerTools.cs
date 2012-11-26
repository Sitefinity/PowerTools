using System;
using System.Linq;
using Autofac;
using Sitefinity.PowerTools.RootTemplates;

namespace Sitefinity.PowerTools
{
    public sealed class PowerTools
    {
        private PowerTools()
        {
        }

        public static PowerTools Instance
        {
            get
            {
                return PowerTools.instance;
            }
        }

        public IRootTemplatesManager RootTemplates
        {
            get
            {
                return this.Container.Resolve<IRootTemplatesManager>();
            }
        }

        public IContainer Container
        {
            get
            {
                if (this.container == null)
                {
                    var containerBuilder = new ContainerBuilder();
                    this.ConfigureContainer(containerBuilder);
                    this.container = containerBuilder.Build();
                }
                return this.container;
            }
        }

        private void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<RootTemplatesManager>()
                            .As<IRootTemplatesManager>();
        }

        private static readonly PowerTools instance = new PowerTools();
        private IContainer container;
    }
}

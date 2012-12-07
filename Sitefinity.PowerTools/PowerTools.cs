using System;
using System.Linq;
using Autofac;
using Sitefinity.PowerTools.Mvc;
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

        public IMvcManager Mvc
        {
            get
            {
                return this.Container.Resolve<IMvcManager>();
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
            containerBuilder.RegisterType<MvcManager>()
                            .As<IMvcManager>();
            containerBuilder.RegisterType<MvcDesignerStore>()
                            .As<IMvcDesignerStore>()
                            .SingleInstance();
        }

        private static readonly PowerTools instance = new PowerTools();
        private IContainer container;
    }
}

using System;
using System.Linq;
using Autofac;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Data;

namespace Sitefinity.PowerTools.RootTemplates
{
    public class RootTemplatesManager : IRootTemplatesManager
    {
        public RootTemplatesManager()
        {
            Bootstrapper.Initialized += this.Bootstrapper_Initialized;
        }

        public void RegisterMvcTemplateResolver<TResolver>()
            where TResolver : IRootTemplateResolver
        {
            this.RegisterMvcTemplateResolver(typeof(TResolver));
        }

        public void RegisterMvcTemplateResolver(Type rootTemplateResolverType)
        {
            this.ValidateResolverArgument(rootTemplateResolverType);
            this.mvcTemplateResolverType = rootTemplateResolverType;

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType(rootTemplateResolverType)
                            .Named("Mvc", typeof(IRootTemplateResolver));

            containerBuilder.Update(PowerTools.Instance.Container);
        }

        public void RegisterWebFormsTemplateResolver<TResolver>()
            where TResolver : IRootTemplateResolver
        {
            this.RegisterWebFormsTemplateResolver(typeof(TResolver));
        }

        public void RegisterWebFormsTemplateResolver(Type rootTemplateResolverType)
        {
            this.ValidateResolverArgument(rootTemplateResolverType);
            this.webFormsTemplateResolverType = rootTemplateResolverType;

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType(rootTemplateResolverType)
                            .Named("WebForms", typeof(IRootTemplateResolver));

            containerBuilder.Update(PowerTools.Instance.Container);
        }

        private void ValidateResolverArgument(Type rootTemplateResolverType)
        {
            if (rootTemplateResolverType == null)
                throw new ArgumentNullException("rootTemplateResolverType");

            if (!typeof(IRootTemplateResolver).IsAssignableFrom(rootTemplateResolverType))
                throw new ArgumentException(string.Format("The type '{0}' must implement IRootTemplateResolver interface"), rootTemplateResolverType.FullName);
        }

        private void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (this.mvcTemplateResolverType != null)
            {
                ObjectFactory.Container.RegisterType<IVirtualFileResolver, ExtendedMvcPageResolver>("PureMvcPageResolver",
                    new ContainerControlledLifetimeManager(), new InjectionConstructor());
            }

            if (this.webFormsTemplateResolverType != null)
            {
                ObjectFactory.Container.RegisterType<IVirtualFileResolver, ExtendedWebFormsPageResolver>("PageResolver",
                    new ContainerControlledLifetimeManager(), new InjectionConstructor());
            }

            Bootstrapper.Initialized -= this.Bootstrapper_Initialized;
        }

        private Type mvcTemplateResolverType;
        private Type webFormsTemplateResolverType;
    }

}

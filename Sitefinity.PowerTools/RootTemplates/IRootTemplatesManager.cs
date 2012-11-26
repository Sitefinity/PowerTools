using System;

namespace Sitefinity.PowerTools.RootTemplates
{
    public interface IRootTemplatesManager
    {
        void RegisterMvcTemplateResolver<TResolver>() where TResolver : IRootTemplateResolver;
        void RegisterMvcTemplateResolver(Type rootTemplateResolverType);
        void RegisterWebFormsTemplateResolver<TResolver>() where TResolver : IRootTemplateResolver;
        void RegisterWebFormsTemplateResolver(Type rootTemplateResolverType);
    }
}
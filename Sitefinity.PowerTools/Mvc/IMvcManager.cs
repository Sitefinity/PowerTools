using System;

namespace Sitefinity.PowerTools.Mvc
{
    public interface IMvcManager
    {
        void RegisterDesigners();

        void RegisterDesigner<TControllerWidget, TControllerDesigner>();
    }
}
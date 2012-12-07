using System;
using System.Web.Mvc;

namespace Sitefinity.PowerTools.Mvc
{
    public interface IMvcManager
    {
        void RegisterDesigner<TControllerWidget, TControllerDesigner>() where TControllerDesigner : IController;
    }
}
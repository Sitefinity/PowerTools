using System;
using System.Linq;
using Sitefinity.PowerTools.Mvc;
using Telerik.Sitefinity.Mvc.Proxy;

namespace Sitefinity.PowerTools.Test.Mvc
{
    public class ExtendedPropertyEditorWrapper : ExtendedPropertyEditor
    {
        public MvcControllerProxy InvokeResolveMvcDesigner(Type widgetType)
        {
            return base.ResolveMvcDesigner(widgetType);
        }
    }
}

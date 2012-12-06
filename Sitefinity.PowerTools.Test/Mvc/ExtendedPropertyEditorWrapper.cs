using System;
using System.Linq;
using Sitefinity.PowerTools.Mvc;
using Telerik.Sitefinity.Mvc.Proxy;
using Telerik.Sitefinity.Pages.Model;

namespace Sitefinity.PowerTools.Test.Mvc
{
    public class ExtendedPropertyEditorWrapper : ExtendedPropertyEditor
    {
        public MvcControllerProxy InvokeResolveMvcDesigner(Type widgetType)
        {
            return base.ResolveMvcDesigner(widgetType);
        }

        public Type InvokeResolveWidgetType(ControlData controlData)
        {
            return base.ResolveWidgetType(controlData);
        }

    }
}

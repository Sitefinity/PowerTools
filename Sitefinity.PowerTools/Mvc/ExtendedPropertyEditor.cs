using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using Autofac;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Mvc.Proxy;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web.UI;

namespace Sitefinity.PowerTools.Mvc
{
    public class ExtendedPropertyEditor : PropertyEditor
    {
        public override string ClientComponentType
        {
            get
            {
                return typeof(PropertyEditor).FullName;
            }
        }

        protected override void PrepareControlDesigner(ControlData ctrlData)
        {
            var mvcDesigner = this.ResolveMvcDesigner(this.ResolveWidgetType(ctrlData));
            if (mvcDesigner == null)
            {
                base.PrepareControlDesigner(ctrlData);
            }
            else
            {
                var stringWriter = new StringWriter();
                var htmlWriter = new HtmlTextWriter(stringWriter);
                mvcDesigner.RenderControl(htmlWriter);
                var designerLiteral = new LiteralControl() { Text = stringWriter.ToString() };

                this.implementsDesigner = true;
                this.Container.GetControl<Control>("simpleModeView", true).Controls.Add(designerLiteral);

                if (mvcDesigner.Controller.ViewBag.Styles != null)
                {
                    var styles = mvcDesigner.Controller.ViewBag.Styles;
                    foreach (var style in styles)
                    {
                        this.Page.Header.Controls.Add(new LiteralControl() { Text = style.ToHtmlString() });
                    }
                }

                if (mvcDesigner.Controller.ViewBag.Scripts != null)
                {
                    var scripts = mvcDesigner.Controller.ViewBag.Scripts;
                    foreach (var script in scripts)
                    {
                        this.Page.Controls.Add(new LiteralControl() { Text = script.ToHtmlString() });
                    }
                }
            }
        }

        protected virtual MvcControllerProxy ResolveMvcDesigner(Type widgetType)
        {
            var store = PowerTools.Instance.Container.Resolve<IMvcDesignerStore>();
            if (!store.MvcDesigners.ContainsKey(widgetType))
                return null;

            var designerControllerType = store.MvcDesigners[widgetType];

            var mvcProxy = new MvcControllerProxy();
            mvcProxy.ControllerName = designerControllerType.FullName;

            return mvcProxy;
        }

        private Type ResolveWidgetType(ControlData ctrlData)
        {
            // different logic for MvcControllerProxy, as designer needs to be obtained from the 
            // controller
            if (ctrlData.ObjectType == typeof(MvcControllerProxy).FullName)
            {
                var controllerName = ctrlData.Properties.Where(p => p.Name == "ControllerName" && p.Value != null).First().Value;
                var controllerType = TypeResolutionService.ResolveType(controllerName);
                return controllerType;
            }
            else
            {
                return TypeResolutionService.ResolveType(PageManager.GetControlType(ctrlData).AssemblyQualifiedName);
            }
        }

    }
}

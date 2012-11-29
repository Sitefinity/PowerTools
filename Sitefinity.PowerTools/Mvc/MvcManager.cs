using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Web.UI;
using Autofac;

namespace Sitefinity.PowerTools.Mvc
{
    public class MvcManager : IMvcManager
    {
        public MvcManager()
        {
            Bootstrapper.Initialized += Bootstrapper_Initialized;
        }

        void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            this.ReplacePropertyEditorDialog();
        }

        

        public void RegisterDesigners()
        {
            throw new NotImplementedException();
        }

        public void RegisterDesigner<TControllerWidget, TControllerDesigner>()
        {
            var store = PowerTools.Instance.Container.Resolve<IMvcDesignerStore>();
            store.MvcDesigners.Add(typeof(TControllerWidget), typeof(TControllerDesigner));
        }

        private void ReplacePropertyEditorDialog()
        {
            ObjectFactory.Container.RegisterType(typeof(DialogBase), typeof(ExtendedPropertyEditor), typeof(PropertyEditor).Name);
        }
    }
}

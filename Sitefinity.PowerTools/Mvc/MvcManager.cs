using System;
using System.Linq;
using System.Web.Mvc;
using Autofac;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Web.UI;

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

        public void RegisterDesigner<TControllerWidget, TControllerDesigner>()
            where TControllerDesigner : IController
        {
            var store = PowerTools.Instance.Container.Resolve<IMvcDesignerStore>();

            if(store.MvcDesigners.ContainsKey(typeof(TControllerWidget)))
                throw new ArgumentException(string.Format("A designer for widget of type '{0}' has already been registered.", typeof(TControllerWidget).FullName));

            store.MvcDesigners.Add(typeof(TControllerWidget), typeof(TControllerDesigner));
        }

        private void ReplacePropertyEditorDialog()
        {
            ObjectFactory.Container.RegisterType(typeof(DialogBase), typeof(ExtendedPropertyEditor), typeof(PropertyEditor).Name);
        }
    }
}

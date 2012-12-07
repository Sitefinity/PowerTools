using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitefinity.PowerTools.Mvc
{
    public class MvcDesignerStore : IMvcDesignerStore
    {
        public Dictionary<Type, Type> MvcDesigners
        {
            get
            {
                if (this.mvcDesigners == null)
                    this.mvcDesigners = new Dictionary<Type, Type>();
                return this.mvcDesigners;
            }
        }

        private Dictionary<Type, Type> mvcDesigners;
    }
}

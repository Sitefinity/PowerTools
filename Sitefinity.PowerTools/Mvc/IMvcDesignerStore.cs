using System;
using System.Collections.Generic;

namespace Sitefinity.PowerTools.Mvc
{
    public interface IMvcDesignerStore
    {
        Dictionary<Type, Type> MvcDesigners { get; }
    }
}
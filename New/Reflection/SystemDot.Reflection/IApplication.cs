using System;
using System.Collections.Generic;

namespace SystemDot.Reflection
{
    public interface IApplication
    {
        IEnumerable<Type> GetAllTypes();
    }
}
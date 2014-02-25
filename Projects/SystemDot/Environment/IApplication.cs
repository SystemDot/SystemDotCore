using System;
using System.Collections.Generic;

namespace SystemDot.Environment
{
    public interface IApplication
    {
        IEnumerable<Type> GetAllTypes();
    }
}
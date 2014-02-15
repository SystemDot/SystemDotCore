using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SystemDot.Core;

namespace SystemDot.Environment
{
    public class Application : IApplication
    {
        public IEnumerable<Type> GetAllTypes()
        {
            return GetAssemblies().SelectMany(a => a.ExportedTypes);
        }

        IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SystemDot.Reflection
{
    public class Application : IApplication
    {
        public IEnumerable<Type> GetAllTypes()
        {
            return GetAssemblies().SelectMany(GetTypes);
                
        }

        IEnumerable<Type> GetTypes(Assembly assembly)
        {
            if (assembly.IsDynamic) return new List<Type>();

            try
            {
                return assembly.ExportedTypes;
            }
            catch (NotSupportedException)
            {
                return new List<Type>();
            }
        }

        IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}

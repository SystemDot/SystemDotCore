﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SystemDot.Reflection
{
    using System.IO;

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
            catch (FileLoadException)
            {
                return new List<Type>();
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
